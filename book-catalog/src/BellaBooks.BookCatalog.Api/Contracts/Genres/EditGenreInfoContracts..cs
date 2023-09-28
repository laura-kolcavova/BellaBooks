namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class EditGenreInfoContracts
{
    public record Request
    {
        public required int GenreId { get; init; }

        public required string Name { get; init; }
    }
}
