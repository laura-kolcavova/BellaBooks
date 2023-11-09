using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Domain.Books.ReadModels;

public class BookListingItemReadModel
{
    public required int Id { get; init; }

    public required string Isbn { get; init; }

    public required string Title { get; init; }

    public required short PublicaitonYear { get; init; }

    public required string PublicationLanguage { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublisherName { get; init; }

    public required IReadOnlyCollection<string> AuthorsNames { get; set; }

    public required IReadOnlyCollection<LibraryPrintStateCode> LibraryPrintStateCodes { get; set; }
}
