using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.AddBook;

internal class AddBookResponseMapper : ResponseMapper<
    AddBookContracts.Response, int>
{
    public override AddBookContracts.Response FromEntity(int e)
    {
        return new()
        {
            BookId = e,
        };
    }
}
