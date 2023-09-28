namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class RemoveGenreContracts
{
    public record Request
    {
        public required int GenreId { get; init; }
    }
}
