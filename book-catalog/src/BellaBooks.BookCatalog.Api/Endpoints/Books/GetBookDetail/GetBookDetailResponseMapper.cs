using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

internal class GetBookDetailResponseMapper : ResponseMapper<
    GetBookDetailContracts.ResponseDto, BookDetailReadModel?>
{
    public override GetBookDetailContracts.ResponseDto FromEntity(BookDetailReadModel? e)
    {
        return new()
        {
            BookDetail = e == null
                ? null
                : BookDetailDto.FromEntity(e),
        };
    }
}
