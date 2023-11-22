namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAllAuthorsContracts
{
    public record ResponseDto
    {
        public required IReadOnlyCollection<AuthorDetailDto> Authors { get; init; }
    }
}
