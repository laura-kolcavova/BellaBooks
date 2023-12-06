using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Application.Features.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

internal class GetBookDetailEndpoint : Endpoint
    <GetBookDetailContracts.RequestDto,
    Ok<GetBookDetailContracts.ResponseDto>,
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
        Ok<GetBookDetailContracts.ResponseDto>>
        ExecuteAsync(GetBookDetailContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new GetBookDetailQuery
        {
            BookId = req.BookId,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
