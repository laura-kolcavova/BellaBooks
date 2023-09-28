namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAuthorDetailContracts
{
    public record Request
    {
        public required int AuthorId { get; init; }
    }

    public record Response
    {
        public required AuthorDetailDto? Author { get; init; }
    }
}
