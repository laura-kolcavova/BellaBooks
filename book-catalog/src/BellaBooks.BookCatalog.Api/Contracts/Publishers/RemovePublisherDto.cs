namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class RemovePublisherDto
{
    public record Request
    {
        public required int PublisherId { get; init; }
    }
}
