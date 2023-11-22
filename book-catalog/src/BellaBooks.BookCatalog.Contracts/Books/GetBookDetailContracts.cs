namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class GetBookDetailContracts
{
    public record RequestDto
    {
        public required int BookId { get; init; }
    }

    public record ResponseDto
    {
        public required BookDetailDto? BookDetail { get; init; }
    }
}
