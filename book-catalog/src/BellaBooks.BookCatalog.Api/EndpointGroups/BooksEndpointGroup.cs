using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

public class BooksEndpointGroup : Group
{
    public BooksEndpointGroup()
    {
        Configure("Books", ep => { });
    }
}
