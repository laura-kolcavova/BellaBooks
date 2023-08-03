using BellaBooks.BookCatalog.Domain.Genres;

namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public record GenreDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public static GenreDto FromEntity(GenreEntity genre)
    {
        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
}
