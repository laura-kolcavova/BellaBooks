namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAuthorDetailDto
{
    public record Request
    {
        public required int AuthorId { get; init; }
    }

    public record Response
    {
        public required AuthorDto Author { get; init; }
    }
}
