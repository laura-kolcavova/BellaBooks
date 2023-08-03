using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.SimpleSearchBooks;

public class SimpleSearchBooksMapper : Mapper<
    SimpleSearchBooksDto.Request,
    SimpleSearchBooksDto.Response,
    ICollection<BookListingItemReadModel>>
{
    public override SimpleSearchBooksDto.Response FromEntity(ICollection<BookListingItemReadModel> e)
    {
        return new()
        {
            Books = e
                .Select(BookListingItemDto.FromEntity)
                .ToList(),
        };
    }
}
