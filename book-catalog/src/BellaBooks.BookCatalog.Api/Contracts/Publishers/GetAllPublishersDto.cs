namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class GetAllPublishersDto
{
    public record Response
    {
        public required ICollection<PublisherDto> Publishers { get; init; }
    }
}
