using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.RemoveLibraryPrint;

public class RemoveLibraryPrintRequestValidator : Validator<RemoveLibraryPrintContracts.Request>
{
    public RemoveLibraryPrintRequestValidator()
    {
        RuleFor(x => x.LibraryPrintId)
          .GreaterThan(0);
    }
}
