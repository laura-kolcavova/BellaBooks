namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class RemoveGenreContracts
{
    public record RequestDto
    {
        public required int GenreId { get; init; }
    }
}
