using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.SimpleSearchBooks;

internal class SimpleSearchBooksEndpoint : Endpoint<
    SimpleSearchBooksContracts.Request,
    Ok<SimpleSearchBooksContracts.Response>,
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
        Ok<SimpleSearchBooksContracts.Response>>
        ExecuteAsync(SimpleSearchBooksContracts.Request req, CancellationToken ct)
    {
        var books = await new SimpleSearchBooksCommand
        {
            SearchInput = req.SearchInput ?? string.Empty,
            Filter = req.Filter,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(books));
    }
}
