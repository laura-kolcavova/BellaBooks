namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class RemoveGenreDto
{
    public record Request
    {
        public required int GenreId { get; init; }
    }
}
