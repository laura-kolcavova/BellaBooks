using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

public class GetPublisherDetailResponseMapper : ResponseMapper<
    GetPublisherDetailDto.Response,
    PublisherEntity>
{
    public override GetPublisherDetailDto.Response FromEntity(PublisherEntity e)
    {
        return new()
        {
            Publisher = PublisherDto.FromEntity(e),
        };
    }
}
