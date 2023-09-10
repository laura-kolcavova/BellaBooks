namespace BellaBooks.BookCatalog.Api.Contracts.Authors;

public static class EditAuthorInfoDto
{
    public record Request
    {
        public required int AuthorId { get; init; }

        public required string Name { get; init; }
    }
}
