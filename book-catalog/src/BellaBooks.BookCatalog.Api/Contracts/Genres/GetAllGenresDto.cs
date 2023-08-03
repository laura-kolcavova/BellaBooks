namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class GetAllGenresDto
{
    public record Response
    {
        public required ICollection<GenreDto> Genres { get; init; }
    }
}
