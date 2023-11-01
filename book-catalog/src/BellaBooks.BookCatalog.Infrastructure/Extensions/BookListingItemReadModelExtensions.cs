using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using static BellaBooks.BookCatalog.Domain.Books.ReadModels.BookListingItemReadModel;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

internal static class BookListingItemReadModelExtensions
{
    public static BookListingItemReadModel FromBookEntity(BookEntity book)
    {
        return new BookListingItemReadModel
        {
            Id = book.Id,
            Title = book.Title,
            PublicaitonYear = book.PublicationInfo.Year,
            PublicationCity = book.PublicationInfo.City,
            PublicationLanguage = book.PublicationInfo.Language,
            Publisher = new PublisherInfoReadModel
            {
                Name = book.Publisher!.Name
            },
            Authors = book.BookAuthors
                .Select(ab => new AuthorInfoReadModel
                {
                    Name = ab.Author.Name
                })
                .ToList(),
            LibraryPrintsInfo = new LibraryPrintsInfoReadModel
            {
                Count = book.LibraryPrints.Count,
                CountPerLibraryPrintStateCodes = book.LibraryPrints
                             .GroupBy(libraryPrint => libraryPrint.StateCode)
                             .ToDictionary(
                                 group => group.Key,
                                 group => group.Count())
            },
        };
    }
}
