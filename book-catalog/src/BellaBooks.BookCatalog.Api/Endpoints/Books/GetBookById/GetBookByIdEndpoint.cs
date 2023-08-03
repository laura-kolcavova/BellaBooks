using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.GetBookById;

public class GetBookByIdEndpoint : Endpoint
    <GetBookByIdDto.Request,
    Results<Ok<GetBookByIdDto.Response>, NotFound>,
    GetBookByIdMapper>
{
    public override void Configure()
    {
        Get("Book/{bookId}");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Searches for a specific book by its Id";
            s.Description = "The endpoint will return a book detail";
        });
    }

    public override async Task<Results<
        Ok<GetBookByIdDto.Response>, NotFound>>
        ExecuteAsync(GetBookByIdDto.Request req, CancellationToken ct)
    {
        var result = await new GetBookByIdCommand
        {
            BookId = req.BookId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound or
                _ => TypedResults.NotFound()
            };
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
