namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class AddAuthorContracts
{
    public record Request
    {
        public required string Name { get; init; }
    }

    public record Response
    {
        public required int AuthorId { get; init; }
    }
}
