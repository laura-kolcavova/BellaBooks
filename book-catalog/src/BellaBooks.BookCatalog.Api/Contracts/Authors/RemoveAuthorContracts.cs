namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class RemoveAuthorContracts
{
    public record Request
    {
        public required int AuthorId { get; init; }
    }
}
