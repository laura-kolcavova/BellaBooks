namespace BellaBooks.BookCatalog.Api.Contracts.Genres;

public static class GetAllGenresContracts
{
    public record ResponseDto
    {
        public required IReadOnlyCollection<GenreDetailDto> Genres { get; init; }
    }
}
