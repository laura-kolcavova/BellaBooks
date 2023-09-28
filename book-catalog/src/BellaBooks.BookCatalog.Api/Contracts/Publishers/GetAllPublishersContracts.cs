namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetAllPublishersContracts
{
    public record Response
    {
        public required ICollection<PublisherDetailDto> Publishers { get; init; }
    }
}
