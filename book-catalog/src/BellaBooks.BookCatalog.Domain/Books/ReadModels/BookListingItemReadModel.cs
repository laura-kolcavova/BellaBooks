using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Domain.Books.ReadModels;

public class BookListingItemReadModel
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required short PublicaitonYear { get; init; }

    public required string PublicationLanguage { get; init; }

    public required string PublicationCity { get; init; }

    public required PublisherInfoReadModel Publisher { get; init; }

    public required IReadOnlyCollection<AuthorInfoReadModel> Authors { get; init; }

    public required LibraryPrintsInfoReadModel LibraryPrintsInfo { get; init; }

    public class PublisherInfoReadModel
    {
        public required string Name { get; init; }
    }

    public class AuthorInfoReadModel
    {
        public required string Name { get; init; }
    }

    public class LibraryPrintsInfoReadModel
    {
        public required int Count { get; init; }

        public required IReadOnlyDictionary<LibraryPrintStateCode, int> CountPerLibraryPrintStateCodes { get; init; }
    }
}
