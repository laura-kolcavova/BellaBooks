namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class RemovePublisherContracts
{
    public record Request
    {
        public required int PublisherId { get; init; }
    }
}
