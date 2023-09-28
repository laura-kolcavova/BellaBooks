namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class GetGenreDetailContracts
{
    public record Request
    {
        public required int GenreId { get; init; }
    }

    public record Response
    {
        public required GenreDetailDto? Genre { get; init; }
    }
}
