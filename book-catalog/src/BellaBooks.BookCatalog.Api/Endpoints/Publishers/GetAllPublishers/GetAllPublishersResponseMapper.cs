using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetAllPublishers;

internal class GetAllPublishersResponseMapper : ResponseMapper<
    GetAllPublishersContracts.ResponseDto,
    ICollection<PublisherEntity>>
{
    public override GetAllPublishersContracts.ResponseDto FromEntity(ICollection<PublisherEntity> e)
    {
        return new()
        {
            Publishers = e
                .Select(PublisherDetailDto.FromEntity)
                .ToList()
        };
    }
}
