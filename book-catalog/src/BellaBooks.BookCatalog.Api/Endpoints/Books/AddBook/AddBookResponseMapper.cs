using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.AddBook;

public class AddBookResponseMapper : ResponseMapper<
    AddBookDto.Response,
    int>
{
    public override AddBookDto.Response FromEntity(int e)
    {
        return new()
        {
            BookId = e,
        };
    }
}
