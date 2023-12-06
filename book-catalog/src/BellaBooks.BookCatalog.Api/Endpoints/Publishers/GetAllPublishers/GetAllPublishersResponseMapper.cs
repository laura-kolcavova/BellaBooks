using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetAllPublishers;

internal class GetAllPublishersResponseMapper : ResponseMapper<
    GetAllPublishersContracts.ResponseDto,
    IReadOnlyCollection<PublisherDetailReadModel>>
{
    public override GetAllPublishersContracts.ResponseDto FromEntity(IReadOnlyCollection<PublisherDetailReadModel> e)
    {
        return new()
        {
            Publishers = e
                .Select(PublisherDetailDto.FromEntity)
                .ToList()
        };
    }
}
