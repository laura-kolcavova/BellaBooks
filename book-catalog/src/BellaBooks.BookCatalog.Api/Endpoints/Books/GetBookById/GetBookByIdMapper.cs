using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.GetBookById;

public class GetBookByIdMapper : Mapper<
    GetBookByIdDto.Request,
    GetBookByIdDto.Response,
    BookEntity>
{
    public override GetBookByIdDto.Response FromEntity(BookEntity e)
    {
        return new()
        {
            BookDetail = BookDetailDto.FromEntity(e),
        };
    }
}
