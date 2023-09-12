using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.AddLibraryPrint;

public class AddLibraryPrintResponseMapper : ResponseMapper<
    AddLibraryPrintDto.Response, int>
{
    public override AddLibraryPrintDto.Response FromEntity(int e)
    {
        return new()
        {
            LibraryPrintId = e
        };
    }
}
