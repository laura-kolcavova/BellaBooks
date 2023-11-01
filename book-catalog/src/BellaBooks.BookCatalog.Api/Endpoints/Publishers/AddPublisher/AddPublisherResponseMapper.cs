using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

internal class AddPublisherResponseMapper : ResponseMapper<
    AddPublisherContracts.ResponseDto, int>
{
    public override AddPublisherContracts.ResponseDto FromEntity(int e)
    {
        return new()
        {
            PublisherId = e,
        };
    }
}
