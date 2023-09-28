namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAllAuthorsContracts
{
    public record Response
    {
        public required ICollection<AuthorDetailDto> Authors { get; init; }
    }
}
