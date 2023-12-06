using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.ActivateLibraryBranch;

internal class ActivateLibraryBranchRequestValidator : Validator<ActivateLibraryBranchContracts.RequestDto>
{
    public ActivateLibraryBranchRequestValidator()
    {
        RuleFor(x => x.LibraryBranchCode)
            .IsLibraryBranchCode();
    }
}
