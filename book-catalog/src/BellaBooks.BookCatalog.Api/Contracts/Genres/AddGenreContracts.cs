namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class AddGenreContracts
{
    public record RequestDto
    {
        public required string Name { get; init; }
    }

    public record ResponseDto
    {
        public required int GenreId { get; init; }
    }
}
