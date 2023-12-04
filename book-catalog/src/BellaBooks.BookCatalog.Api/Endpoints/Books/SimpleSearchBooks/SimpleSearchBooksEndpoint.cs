using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Application.Features.Books.Queries;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.SimpleSearchBooks;

internal class SimpleSearchBooksEndpoint : Endpoint<
    SimpleSearchBooksContracts.RequestDto,
    Ok<SimpleSearchBooksContracts.ResponseDto>,
    SimpleSearchBooksResponseMapper>
{
    public override void Configure()
    {
        Get("SimpleSearch");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {

            s.Summary = "Search for books using simple search method";
            s.Description = "The endpoint will return collection of searched books";
        });
    }

    public override async Task<
        Ok<SimpleSearchBooksContracts.ResponseDto>>
        ExecuteAsync(SimpleSearchBooksContracts.RequestDto req, CancellationToken ct)
    {
        var books = await new SimpleSearchBooksQuery
        {
            SearchInput = req.SearchInput ?? string.Empty,
            Filter = req.Filter,
            OffsetPaginationFilter = new Application.Pagination.OffsetPaginationFilter
            {
                Limit = int.MaxValue,
                Offset = 0
            }
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(books));
    }
}
