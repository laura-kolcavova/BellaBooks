using BellaBooks.BookCatalog.Api.Contracts.Books;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.AddBook;

internal class AddBookResponseMapper : ResponseMapper<
    AddBookContracts.ResponseDto, int>
{
    public override AddBookContracts.ResponseDto FromEntity(int e)
    {
        return new()
        {
            BookId = e,
        };
    }
}
