using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using BellaBooks.BookCatalog.Domain.LibraryPrints.ReadModels;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;

namespace BellaBooks.BookCatalog.Domain.Books.ReadModels;

public class BookDetailReadModel
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required string Isbn { get; init; }

    public required short PublicationYear { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublicationLanguage { get; init; }

    public required short? PageCount { get; init; }

    public required string? Summary { get; init; }

    public required PublisherDetailReadModel Publisher { get; init; }

    public IReadOnlyCollection<AuthorDetailReadModel> Authors { get; set; } = new List<AuthorDetailReadModel>();

    public IReadOnlyCollection<GenreDetailReadModel> Genres { get; set; } = new List<GenreDetailReadModel>();

    public IReadOnlyCollection<LibraryPrintDetailReadModel> LibraryPrints { get; set; } = new List<LibraryPrintDetailReadModel>();
}
