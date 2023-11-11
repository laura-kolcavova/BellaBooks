using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public record BookListingItemDto
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required string Isbn { get; init; }

    public required short PublicationYear { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublicationLanguage { get; init; }

    public required string PublisherName { get; init; }

    public required IReadOnlyCollection<string> AuthorNames { get; init; }

    public required IReadOnlyCollection<LibraryPrintStateCode> LibraryPrintStateCodes { get; init; }

    public static BookListingItemDto FromEntity(BookListingItemReadModel book)
    {
        return new BookListingItemDto
        {
            Id = book.Id,
            Title = book.Title,
            Isbn = book.Isbn,
            PublicationYear = book.PublicaitonYear,
            PublicationLanguage = book.PublicationLanguage,
            PublicationCity = book.PublicationCity,
            PublisherName = book.PublisherName,
            AuthorNames = book.AuthorsNames.ToList(),
            LibraryPrintStateCodes = book.LibraryPrintStateCodes.ToList()
        };
    }
}