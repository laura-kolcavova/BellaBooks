namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class RemoveBookContracts
{
    public record RequestDto
    {
        public required int BookId { get; init; }
    }
}
