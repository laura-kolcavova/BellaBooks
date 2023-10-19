using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

internal class GetBookDetailResponseMapper : ResponseMapper<
    GetBookDetailContracts.Response, BookEntity?>
{
    public override GetBookDetailContracts.Response FromEntity(BookEntity? e)
    {
        return new()
        {
            BookDetail = e == null
                ? null
                : BookDetailDto.FromEntity(e),
        };
    }
}
