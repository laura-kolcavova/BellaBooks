using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.EditLibraryBranchInfo;

internal class EditLibraryBranchInfoRequestValidator :
    Validator<EditLibraryBranchInfoContracts.RequestDto>
{
    public EditLibraryBranchInfoRequestValidator()
    {
        RuleFor(r => r.LibraryBranchCode)
            .IsLibraryBranchCode();

        RuleFor(r => r.LibraryBranchCode)
            .IsLibraryBranchName();
    }
}
