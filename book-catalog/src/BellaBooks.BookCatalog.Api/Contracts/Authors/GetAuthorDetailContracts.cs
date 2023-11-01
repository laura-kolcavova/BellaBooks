namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class GetAuthorDetailContracts
{
    public record RequestDto
    {
        public required int AuthorId { get; init; }
    }

    public record ResponseDto
    {
        public required AuthorDetailDto? Author { get; init; }
    }
}
