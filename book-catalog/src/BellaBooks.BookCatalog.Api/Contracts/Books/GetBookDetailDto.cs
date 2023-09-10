namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class GetBookDetailDto
{
    public class Request
    {
        public required int BookId { get; init; }
    }

    public class Response
    {
        public required BookDetailDto BookDetail { get; init; }
    }
}
