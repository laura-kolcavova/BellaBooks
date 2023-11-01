using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.DeactivateLibraryBranch;

internal class DisableLibraryBranchRequestValidator : Validator<DisableLibraryBranchContracts.RequestDto>
{
    public DisableLibraryBranchRequestValidator()
    {
        RuleFor(x => x.LibraryBranchCode)
            .IsLibraryBranchCode();
    }
}
