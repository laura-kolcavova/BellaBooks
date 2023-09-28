using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

public class AddPublisherResponseMapper : ResponseMapper<
    Contracts.Publishers.AddPublisherContracts.Response,
    int>
{
    public override Contracts.Publishers.AddPublisherContracts.Response FromEntity(int e)
    {
        return new()
        {
            PublisherId = e,
        };
    }
}
