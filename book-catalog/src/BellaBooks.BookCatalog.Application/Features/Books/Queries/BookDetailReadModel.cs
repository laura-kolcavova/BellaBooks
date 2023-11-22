using BellaBooks.BookCatalog.Application.Features.Authors.Queries;
using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Queries;
using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;

namespace BellaBooks.BookCatalog.Application.Features.Books.Queries;

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

    public required int PublisherId { get; init; }

    public required string PublisherName { get; init; }

    public PublisherDetailReadModel Publisher => new()
    {
        Id = PublisherId,
        Name = PublisherName,
    };

    public IReadOnlyCollection<AuthorDetailReadModel> Authors { get; set; } = new List<AuthorDetailReadModel>();

    public IReadOnlyCollection<GenreDetailReadModel> Genres { get; set; } = new List<GenreDetailReadModel>();

    public IReadOnlyCollection<LibraryPrintDetailReadModel> LibraryPrints { get; set; } = new List<LibraryPrintDetailReadModel>();
}
