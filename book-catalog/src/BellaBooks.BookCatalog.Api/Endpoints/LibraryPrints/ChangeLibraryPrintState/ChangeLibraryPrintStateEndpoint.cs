using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.LibraryPrints.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.ChangeLibraryPrintState;

public class ChangeLibraryPrintStateEndpoint : Endpoint<
    ChangeLibraryPrintStateContracts.Request,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("ChangeLibraryPrintState");
        Group<LibraryPrintEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Changes a library print state";
            s.Description = "The endpoint will change a library print state";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(ChangeLibraryPrintStateContracts.Request req, CancellationToken ct)
    {
        var result = await new ChangeLibaryPrintStateCommand()
        {
            LibraryPrintId = req.LibraryPrintId,
            StateCode = req.StateCode
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
               result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
