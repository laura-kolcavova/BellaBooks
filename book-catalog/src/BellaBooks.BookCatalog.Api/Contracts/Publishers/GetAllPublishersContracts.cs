namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetAllPublishersContracts
{
    public record ResponseDto
    {
        public required ICollection<PublisherDetailDto> Publishers { get; init; }
    }
}
