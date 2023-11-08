using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class PublisherDetailReadModelExtensions
{
    public static PublisherDetailReadModel FromEntity(PublisherEntity entity)
    {
        return new PublisherDetailReadModel
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
