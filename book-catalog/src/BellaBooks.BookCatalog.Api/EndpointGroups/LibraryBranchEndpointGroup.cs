using MediatR;

namespace BellaBooks.BookCatalog.Api.EndpointGroups;

internal class LibraryBranchEndpointGroup : Group
{
    public LibraryBranchEndpointGroup()
    {
        Configure("LibraryBranches", ep => { });
    }
}
