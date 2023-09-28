using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

public class GetPublisherDetailResponseMapper : ResponseMapper<
    Contracts.Publishers.GetPublisherDetailContracts.Response,
    PublisherEntity?>
{
    public override Contracts.Publishers.GetPublisherDetailContracts.Response FromEntity(PublisherEntity? e)
    {
        return new()
        {
            Publisher = e == null
                ? null
                : PublisherDetailDto.FromEntity(e),
        };
    }
}
