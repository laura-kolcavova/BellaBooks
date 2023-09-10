using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetAllPublishers;

public class GetAllPublishersResponseMapper : ResponseMapper<
    GetAllPublishersDto.Response,
    ICollection<PublisherEntity>>
{
    public override GetAllPublishersDto.Response FromEntity(ICollection<PublisherEntity> e)
    {
        return new()
        {
            Publishers = e
                .Select(PublisherDto.FromEntity)
                .ToList()
        };
    }
}
