namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class AddGenreDto
{
    public record Request
    {
        public required string Name { get; init; }
    }
}
