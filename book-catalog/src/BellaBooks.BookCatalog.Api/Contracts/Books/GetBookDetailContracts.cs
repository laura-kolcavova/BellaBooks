namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class GetBookDetailContracts
{
    public class Request
    {
        public required int BookId { get; init; }
    }

    public class Response
    {
        public required BookDetailDto? BookDetail { get; init; }
    }
}
