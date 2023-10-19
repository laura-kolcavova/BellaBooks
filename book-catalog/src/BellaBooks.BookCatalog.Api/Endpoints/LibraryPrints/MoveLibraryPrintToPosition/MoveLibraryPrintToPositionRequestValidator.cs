using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.MoveLibraryPrintToPosition;

internal class MoveLibraryPrintToPositionRequestValidator : Validator<MoveLibraryPrintToPositionContracts.RequestDto>
{
    public MoveLibraryPrintToPositionRequestValidator()
    {
        RuleFor(x => x.LibraryPrintId)
            .IsNumericId();

        RuleFor(x => x.LibraryBranchCode)
            .IsLibraryBranchCode();

        RuleFor(x => x.Shelfmark)
            .NotEmpty();
    }
}
