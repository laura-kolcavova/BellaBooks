namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class RemoveAuthorContracts
{
    public record RequestDto
    {
        public required int AuthorId { get; init; }
    }
}
