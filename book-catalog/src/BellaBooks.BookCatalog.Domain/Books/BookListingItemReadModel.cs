using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Publishers;

namespace BellaBooks.BookCatalog.Domain.Books;

public class BookListingItemReadModel
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required short PublicaitonYear { get; init; }

    public required string PublicationLanguage { get; init; }

    public required string PublicationCity { get; init; }

    public required PublisherEntity Publisher { get; init; }

    public required ICollection<AuthorEntity> Authors { get; init; }

    public bool IsAvailable { get; init; }
}
