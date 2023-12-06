using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

internal class GetPublisherDetailResponseMapper : ResponseMapper<
    GetPublisherDetailContracts.ResponseDto, PublisherDetailReadModel?>
{
    public override GetPublisherDetailContracts.ResponseDto FromEntity(PublisherDetailReadModel? e)
    {
        return new()
        {
            Publisher = e == null
                ? null
                : PublisherDetailDto.FromEntity(e),
        };
    }
}
