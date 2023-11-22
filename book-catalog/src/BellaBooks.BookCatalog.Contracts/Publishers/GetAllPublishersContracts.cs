namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetAllPublishersContracts
{
    public record ResponseDto
    {
        public required IReadOnlyCollection<PublisherDetailDto> Publishers { get; init; }
    }
}
