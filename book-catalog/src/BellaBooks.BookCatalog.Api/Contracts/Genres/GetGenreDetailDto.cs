namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class GetGenreDetailDto
{
    public record Request
    {
        public required int GenreId { get; init; }
    }

    public record Response
    {
        public required GenreDto Genre { get; init; }
    }
}
