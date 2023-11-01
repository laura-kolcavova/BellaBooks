namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAllAuthorsContracts
{
    public record ResponseDto
    {
        public required ICollection<AuthorDetailDto> Authors { get; init; }
    }
}
