using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;

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
