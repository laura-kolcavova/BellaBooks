using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.AddBook;

public class AddBookResponseMapper : ResponseMapper<
    Contracts.Books.AddBookContracts.Response,
    int>
{
    public override Contracts.Books.AddBookContracts.Response FromEntity(int e)
    {
        return new()
        {
            BookId = e,
        };
    }
}
