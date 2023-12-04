namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class GetGenreDetailContracts
{
    public record RequestDto
    {
        public required int GenreId { get; init; }
    }

    public record ResponseDto
    {
        public required GenreDetailDto? Genre { get; init; }
    }
}
