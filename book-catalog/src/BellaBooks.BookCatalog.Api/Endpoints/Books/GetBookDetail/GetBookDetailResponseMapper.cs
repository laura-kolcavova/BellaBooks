using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailResponseMapper : ResponseMapper<
    Contracts.Books.GetBookDetailContracts.Response,
    BookEntity?>
{
    public override Contracts.Books.GetBookDetailContracts.Response FromEntity(BookEntity? e)
    {
        return new()
        {
            BookDetail = e == null
                ? null
                : BookDetailDto.FromEntity(e),
        };
    }
}
