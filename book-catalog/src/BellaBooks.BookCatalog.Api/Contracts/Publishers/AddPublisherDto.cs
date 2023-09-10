namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class AddPublisherDto
{
    public record Request
    {
        public required string Name { get; init; }
    }

    public record Response
    {
        public required int PublisherId { get; init; }
    }
}
