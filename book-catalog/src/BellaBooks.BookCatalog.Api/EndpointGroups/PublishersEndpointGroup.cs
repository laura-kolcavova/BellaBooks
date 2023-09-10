using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

public class PublishersEndpointGroup : Group
{
    public PublishersEndpointGroup()
    {
        Configure("Publishers", ep => { });
    }
}
