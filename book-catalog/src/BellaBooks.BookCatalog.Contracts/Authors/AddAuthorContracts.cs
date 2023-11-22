namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class AddAuthorContracts
{
    public record RequestDto
    {
        public required string Name { get; init; }
    }

    public record ResponseDto
    {
        public required int AuthorId { get; init; }
    }
}
