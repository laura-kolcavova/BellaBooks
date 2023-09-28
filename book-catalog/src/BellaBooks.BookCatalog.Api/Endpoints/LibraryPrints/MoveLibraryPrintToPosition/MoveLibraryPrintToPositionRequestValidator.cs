using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.MoveLibraryPrintToPosition;

public class MoveLibraryPrintToPositionRequestValidator : Validator<MoveLibraryPrintToPositionContracts.Request>
{
    public MoveLibraryPrintToPositionRequestValidator()
    {
        RuleFor(x => x.LibraryPrintId)
          .GreaterThan(0);

        RuleFor(x => x.LibraryBranchCode)
            .NotEmpty()
            .Length(2);

        RuleFor(x => x.Shelfmark)
            .NotEmpty();
    }
}
