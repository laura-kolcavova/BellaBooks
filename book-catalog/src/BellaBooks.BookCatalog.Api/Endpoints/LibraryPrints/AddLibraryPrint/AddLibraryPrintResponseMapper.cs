using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.AddLibraryPrint;

internal class AddLibraryPrintResponseMapper : ResponseMapper<
    AddLibraryPrintContracts.ResponseDto, int>
{
    public override AddLibraryPrintContracts.ResponseDto FromEntity(int e)
    {
        return new()
        {
            LibraryPrintId = e
        };
    }
}
