using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

public class AuthorsEndpointGroup : Group
{
    public AuthorsEndpointGroup()
    {
        Configure("Authors", ep => { });
    }
}
