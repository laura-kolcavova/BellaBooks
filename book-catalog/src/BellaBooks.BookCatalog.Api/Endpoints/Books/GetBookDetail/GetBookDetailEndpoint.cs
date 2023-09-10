using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailEndpoint : Endpoint
    <GetBookDetailDto.Request,
    Results<Ok<GetBookDetailDto.Response>, NotFound>,
    GetBookDetailResponseMapper>
{
    public override void Configure()
    {
        Get("GetBookDetail/{bookId}");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Gets a book detail by its Id";
            s.Description = "The endpoint will return a book detail";
        });
    }

    public override async Task<Results<
        Ok<GetBookDetailDto.Response>, NotFound>>
        ExecuteAsync(GetBookDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetBookDetailCommand
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
