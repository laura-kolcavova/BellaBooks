using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;
using BellaBooks.BookCatalog.Domain.Entities.Publishers;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class PublisherEntityExtensions
{
    public static IQueryable<PublisherDetailReadModel> SelectPublisherDetailReadModel(this IQueryable<PublisherEntity> publishers)
    {
        return publishers
            .Select(publisher => new PublisherDetailReadModel
            {
                Id = publisher.Id,
                Name = publisher.Name,
            });
    }
}
