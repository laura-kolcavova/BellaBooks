using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

internal class AddPublisherResponseMapper : ResponseMapper<
    AddPublisherContracts.Response, int>
{
    public override AddPublisherContracts.Response FromEntity(int e)
    {
        return new()
        {
            PublisherId = e,
        };
    }
}
