using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

internal class GenresEndpointGroup : Group
{
    public GenresEndpointGroup()
    {
        Configure("Genres", ep => { });
    }
}
