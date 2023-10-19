using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.AddLibraryPrint;

internal class AddLibraryPrintResponseMapper : ResponseMapper<
    AddLibraryPrintContracts.Response, int>
{
    public override AddLibraryPrintContracts.Response FromEntity(int e)
    {
        return new()
        {
            LibraryPrintId = e
        };
    }
}
