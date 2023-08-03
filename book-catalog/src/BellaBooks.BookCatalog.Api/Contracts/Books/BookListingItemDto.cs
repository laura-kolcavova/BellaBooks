using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public record BookListingItemDto
{
    public required int Id { get; init; }

    public required string Title { get; init; }

    public required short? PublicationYear { get; init; }

    public required string? PublicationCity { get; init; }

    public required string? PublicationLanguage { get; init; }

    public required PublisherDto? Publisher { get; init; }

    public required IReadOnlyCollection<AuthorDto> Authors { get; init; }

    public required bool IsAvailable { get; init; }

    public static BookListingItemDto FromEntity(BookListingItemReadModel book)
    {
        return new BookListingItemDto
        {
            Id = book.Id,
            Title = book.Title,
            PublicationYear = book.PublicaitonYear,
            PublicationLanguage = book.PublicationLanguage,
            PublicationCity = book.PublicationCity,
            Publisher = PublisherDto
                .FromEntity(book.Publisher),
            Authors = book.Authors
                .Select(AuthorDto.FromEntity)
                .ToList(),
            IsAvailable = book.IsAvailable,
        };
    }
}