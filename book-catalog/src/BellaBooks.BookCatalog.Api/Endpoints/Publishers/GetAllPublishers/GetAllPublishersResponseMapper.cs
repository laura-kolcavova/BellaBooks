using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetAllPublishers;

public class GetAllPublishersResponseMapper : ResponseMapper<
    Contracts.Publishers.GetAllPublishersContracts.Response,
    ICollection<PublisherEntity>>
{
    public override Contracts.Publishers.GetAllPublishersContracts.Response FromEntity(ICollection<PublisherEntity> e)
    {
        return new()
        {
            Publishers = e
                .Select(PublisherDetailDto.FromEntity)
                .ToList()
        };
    }
}
