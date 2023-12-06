using BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryPrints.AddLibraryPrint;

internal class AddLibraryPrintRequestValidator : Validator<AddLibraryPrintContracts.RequestDto>
{
    public AddLibraryPrintRequestValidator()
    {
        RuleFor(x => x.LibraryBranchCode)
            .IsLibraryBranchCode();
    }
}
