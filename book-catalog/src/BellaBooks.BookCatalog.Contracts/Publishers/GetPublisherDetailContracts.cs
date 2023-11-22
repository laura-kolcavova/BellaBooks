namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetPublisherDetailContracts
{
    public record RequestDto
    {
        public required int PublisherId { get; init; }
    }

    public record ResponseDto
    {
        public required PublisherDetailDto? Publisher { get; init; }
    }
}
