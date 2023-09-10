namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class RemoveAuthorDto
{
    public record Request
    {
        public required int AuthorId { get; init; }
    }
}
