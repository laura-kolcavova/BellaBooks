using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.ChangeLibraryPrintState;

internal class ChangeLibraryPrintStateRequestValidator : Validator<
    ChangeLibraryPrintStateContracts.Request>
{
    public ChangeLibraryPrintStateRequestValidator()
    {
        RuleFor(x => x.LibraryPrintId)
            .IsNumericId();
    }
}
