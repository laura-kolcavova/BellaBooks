namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetPublisherDetailDto
{
    public record Request
    {
        public required int PublisherId { get; init; }
    }

    public record Response
    {
        public required PublisherDto Publisher { get; init; }
    }
}
