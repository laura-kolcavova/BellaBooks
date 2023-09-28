using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.ChangeLibraryPrintState;

public class ChangeLibraryPrintRequestValidator : Validator<
    ChangeLibraryPrintStateContracts.Request>
{
    public ChangeLibraryPrintRequestValidator()
    {
        RuleFor(x => x.LibraryPrintId)
          .GreaterThan(0);
    }
}
