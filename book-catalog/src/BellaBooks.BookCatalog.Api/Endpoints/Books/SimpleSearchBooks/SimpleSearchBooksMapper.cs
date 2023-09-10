using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.SimpleSearchBooks;

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
