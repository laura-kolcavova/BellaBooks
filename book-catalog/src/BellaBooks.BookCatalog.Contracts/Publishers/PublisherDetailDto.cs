using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;

namespace BellaBooks.BookCatalog.Api.Contracts.Publishers;

public record PublisherDetailDto
{
    public required int Id { get; init; }

    public required string Name { get; init; }

    public static PublisherDetailDto FromEntity(PublisherDetailReadModel entity)
    {
        return new PublisherDetailDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
