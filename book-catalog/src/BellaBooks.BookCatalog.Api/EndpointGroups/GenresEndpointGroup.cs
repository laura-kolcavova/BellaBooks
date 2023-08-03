using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

public class GenresEndpointGroup : Group
{
    public GenresEndpointGroup()
    {
        Configure("Genres", ep => { });
    }
}
