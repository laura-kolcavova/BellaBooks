using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.MoveLibraryPrintToPosition;

public class MoveLibraryPrintToPosition : Endpoint<
    MoveLibraryPrintToPositionContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("MoveLibraryPrintToPosition");
        Group<LibraryPrintEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Moves a library print to new position";
            s.Description = "The endpoint will move a library print to new position";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(MoveLibraryPrintToPositionContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new MoveLibraryPrintToPositionCommand()
        {
            LibraryPrintId = req.LibraryPrintId,
            LibraryBranchCode = req.LibraryBranchCode,
            Shelfmark = req.Shelfmark,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
               result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
