using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Books.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.RemoveBook;

public class RemoveBookEndpoint : Endpoint<
    RemoveBookDto.Request,
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
            .Produces<ProblemDetailResponse>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetailResponse>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemoveBookDto.Request req, CancellationToken ct)
    {
        var result = await new RemoveBookCommand()
        {
            BookId = req.BookId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound
                 => TypedResultsExtended.ProblemResponse(
                     result.Error.Message, StatusCodes.Status404NotFound, result.Error.Code),

                _ => TypedResultsExtended.ProblemResponse(
                     result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code)
            };
        }

        return TypedResults.Ok();
    }
}
