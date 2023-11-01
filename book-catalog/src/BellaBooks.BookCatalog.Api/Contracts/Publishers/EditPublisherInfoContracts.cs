namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class EditPublisherInfoContracts
{
    public record RequestDto
    {
        public required int PublisherId { get; init; }

        public required string Name { get; init; }
    }
}
