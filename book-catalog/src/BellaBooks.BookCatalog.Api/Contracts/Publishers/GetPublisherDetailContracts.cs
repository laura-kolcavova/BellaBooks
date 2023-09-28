namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetPublisherDetailContracts
{
    public record Request
    {
        public required int PublisherId { get; init; }
    }

    public record Response
    {
        public required PublisherDetailDto? Publisher { get; init; }
    }
}
