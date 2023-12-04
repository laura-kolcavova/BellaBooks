using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Application.Features.Books.Queries;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public record BookDetailDto
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required string Isbn { get; init; }

    public required short PublicationYear { get; init; }

    public required string PublicationCity { get; init; }

    public required string PublicationLanguage { get; init; }

    public required short? PageCount { get; init; }

    public required string? Summary { get; init; }

    public required PublisherDetailDto Publisher { get; init; }

    public required IReadOnlyCollection<AuthorDetailDto> Authors { get; init; }

    public required IReadOnlyCollection<GenreDetailDto> Genres { get; init; }

    public required IReadOnlyCollection<LibraryPrintDetailDto> LibraryPrints { get; init; }

    public static BookDetailDto FromEntity(BookDetailReadModel book)
    {
        return new BookDetailDto
        {
            Id = book.Id,
            Title = book.Title,
            Isbn = book.Isbn,
            PublicationYear = book.PublicationYear,
            PublicationLanguage = book.PublicationLanguage,
            PublicationCity = book.PublicationCity,
            PageCount = book.PageCount,
            Summary = book.Summary,
            Publisher = PublisherDetailDto.FromEntity(book.Publisher),
            Authors = book.Authors
                .Select(AuthorDetailDto.FromEntity)
                .ToList(),
            Genres = book.Genres
                .Select(GenreDetailDto.FromEntity)
                .ToList(),
            LibraryPrints = book.LibraryPrints
                .Select(LibraryPrintDetailDto.FromEntity)
                .ToList()
        };
    }
}