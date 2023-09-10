namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class RemoveBookDto
{
    public record Request
    {
        public required int BookId { get; init; }
    }
}
