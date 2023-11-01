using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

internal class BooksEndpointGroup : Group
{
    public BooksEndpointGroup()
    {
        Configure("Books", ep => { });
    }
}
