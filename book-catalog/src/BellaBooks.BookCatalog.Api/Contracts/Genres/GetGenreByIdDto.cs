namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class GetGenreByIdDto
{
    public record Request
    {
        public required int GenreId { get; init; }
    }

    public record Respone
    {
        public required GenreDto Genre { get; init; }
    }
}
