using MediatR;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

internal class PublishersEndpointGroup : Group
{
    public PublishersEndpointGroup()
    {
        Configure("Publishers", ep => { });
    }
}
