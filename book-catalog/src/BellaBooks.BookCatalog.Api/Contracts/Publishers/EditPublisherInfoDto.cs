namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public static class EditPublisherInfoDto
{
    public record Request
    {
        public required int PublisherId { get; init; }

        public required string Name { get; init; }
    }
}
