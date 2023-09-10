using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

public class AddPublisherResponseMapper : ResponseMapper<
    AddPublisherDto.Response,
    int>
{
    public override AddPublisherDto.Response FromEntity(int e)
    {
        return new()
        {
            PublisherId = e,
        };
    }
}
