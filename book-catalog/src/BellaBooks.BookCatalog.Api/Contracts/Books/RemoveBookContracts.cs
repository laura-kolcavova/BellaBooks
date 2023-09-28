namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class RemoveBookContracts
{
    public record Request
    {
        public required int BookId { get; init; }
    }
}
