namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class EditGenreInfoDto
{
    public record Request
    {
        public required int GenreId { get; init; }

        public required string Name { get; init; }
    }
}
