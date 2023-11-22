namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class EditAuthorInfoContracts
{
    public record RequestDto
    {
        public required int AuthorId { get; init; }

        public required string Name { get; init; }
    }
}
