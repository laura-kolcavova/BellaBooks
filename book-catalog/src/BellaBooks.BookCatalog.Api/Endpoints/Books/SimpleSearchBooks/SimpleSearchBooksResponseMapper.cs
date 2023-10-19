using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.SimpleSearchBooks;

internal class SimpleSearchBooksResponseMapper : ResponseMapper<
    SimpleSearchBooksContracts.Response,
    ICollection<BookListingItemReadModel>>
{
    public override SimpleSearchBooksContracts.Response FromEntity(ICollection<BookListingItemReadModel> e)
    {
        return new()
        {
            Books = e
                .Select(BookListingItemDto.FromEntity)
                .ToList(),
        };
    }
}
