using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.AddLibraryPrint;

public class AddLibraryPrintResponseMapper : ResponseMapper<
    Contracts.LibraryPrints.AddLibraryPrintContracts.Response, int>
{
    public override Contracts.LibraryPrints.AddLibraryPrintContracts.Response FromEntity(int e)
    {
        return new()
        {
            LibraryPrintId = e
        };
    }
}
