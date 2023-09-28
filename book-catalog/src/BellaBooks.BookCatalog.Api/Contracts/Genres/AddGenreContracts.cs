namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class AddGenreContracts
{
    public record Request
    {
        public required string Name { get; init; }
    }

    public record Response
    {
        public required int GenreId { get; init; }
    }
}
