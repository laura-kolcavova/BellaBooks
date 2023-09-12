using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.LibraryPrints.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.AddLibraryPrint;

public class AddLibraryPrintEndpoint : Endpoint<
    AddLibraryPrintDto.Request,
    Results<Ok<AddLibraryPrintDto.Response>, ProblemHttpResult>,
    AddLibraryPrintResponseMapper>
{
    public override void Configure()
    {
        Post("AddLibraryPrint");
        Group<LibraryPrintEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Add a new library print to the catalog";
            s.Description = "The endpoint will add a new library print to the catalog and return its Id";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok<AddLibraryPrintDto.Response>, ProblemHttpResult>>
        ExecuteAsync(AddLibraryPrintDto.Request req, CancellationToken ct)
    {
        var result = await new AddLibraryPrintCommand
        {
            BookId = req.BookId,
            LibraryBranchCode = req.LibraryBranchCode,
            Shelfmark = req.Shelfmark,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
