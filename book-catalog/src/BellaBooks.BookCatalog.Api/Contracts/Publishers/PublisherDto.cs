using BellaBooks.BookCatalog.Domain.Publishers;

namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public record PublisherDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public static PublisherDto FromEntity(PublisherEntity entity)
    {
        return new PublisherDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
