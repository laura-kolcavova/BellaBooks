namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class AddPublisherContracts
{
    public record RequestDto
    {
        public required string Name { get; init; }
    }

    public record ResponseDto
    {
        public required int PublisherId { get; init; }
    }
}
