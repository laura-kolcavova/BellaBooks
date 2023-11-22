using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.Books.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.RemoveBook;

public class RemoveBookEndpoint : Endpoint<
    RemoveBookContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Delete("RemoveBook");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Removes a book from the catalog";
            s.Description = "The endpoint will remove a book from the catalog";
        });

        Description(d => d
            .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemoveBookContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new RemoveBookCommand()
        {
            BookId = req.BookId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
