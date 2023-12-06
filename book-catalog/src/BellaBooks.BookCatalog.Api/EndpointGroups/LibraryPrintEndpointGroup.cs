using MediatR;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

internal class LibraryPrintEndpointGroup : Group
{
    public LibraryPrintEndpointGroup()
    {
        Configure("LibraryPrints", ep => { });
    }
}
