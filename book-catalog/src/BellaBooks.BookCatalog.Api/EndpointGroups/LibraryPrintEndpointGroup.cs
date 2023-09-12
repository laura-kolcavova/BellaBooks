using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

public class LibraryPrintEndpointGroup : Group
{
    public LibraryPrintEndpointGroup()
    {
        Configure("LibraryPrints", ep => { });
    }
}
