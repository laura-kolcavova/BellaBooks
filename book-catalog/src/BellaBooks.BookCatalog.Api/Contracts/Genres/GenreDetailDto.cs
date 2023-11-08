using BellaBooks.BookCatalog.Domain.Genres.ReadModels;

namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public record GenreDetailDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public static GenreDetailDto FromEntity(GenreDetailReadModel genre)
    {
        return new GenreDetailDto
        {
            Id = genre.Id,
            Name = genre.Name,
        };
    }
}
