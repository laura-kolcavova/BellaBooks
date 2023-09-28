using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailEndpoint : Endpoint
    <GetBookDetailContracts.Request,
    Ok<GetBookDetailContracts.Response>,
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

    public override async Task<
        Ok<GetBookDetailContracts.Response>>
        ExecuteAsync(GetBookDetailContracts.Request req, CancellationToken ct)
    {
        var result = await new GetBookDetailCommand
        {
            BookId = req.BookId,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
