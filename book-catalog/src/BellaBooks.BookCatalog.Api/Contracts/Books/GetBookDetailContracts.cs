namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class GetBookDetailContracts
{
    public class RequestDto
    {
        public required int BookId { get; init; }
    }

    public class ResponseDto
    {
        public required BookDetailDto? BookDetail { get; init; }
    }
}
