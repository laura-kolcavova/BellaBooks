using MediatR;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

internal class AuthorsEndpointGroup : Group
{
    public AuthorsEndpointGroup()
    {
        Configure("Authors", ep => { });
    }
}
