using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.SimpleSearchBooks;

internal class SimpleSearchBooksResponseMapper : ResponseMapper<
    SimpleSearchBooksContracts.ResponseDto,
    IReadOnlyCollection<BookListingItemReadModel>>
{
    public override SimpleSearchBooksContracts.ResponseDto FromEntity(IReadOnlyCollection<BookListingItemReadModel> e)
    {
        return new()
        {
            Books = e
                .Select(BookListingItemDto.FromEntity)
                .ToList(),
        };
    }
}
