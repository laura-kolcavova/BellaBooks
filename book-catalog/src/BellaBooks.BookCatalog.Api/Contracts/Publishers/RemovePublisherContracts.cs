namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class RemovePublisherContracts
{
    public record RequestDto
    {
        public required int PublisherId { get; init; }
    }
}
