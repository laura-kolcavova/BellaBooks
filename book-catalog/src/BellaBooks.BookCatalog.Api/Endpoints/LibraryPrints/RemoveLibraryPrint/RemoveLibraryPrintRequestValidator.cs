using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.RemoveLibraryPrint;

internal class RemoveLibraryPrintRequestValidator : Validator<RemoveLibraryPrintContracts.Request>
{
    public RemoveLibraryPrintRequestValidator()
    {
        RuleFor(x => x.LibraryPrintId)
          .IsNumericId();
    }
}
