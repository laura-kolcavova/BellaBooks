using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.RemoveLibraryBranch;

internal class RemoveLibraryBranchRequestValidator : Validator<RemoveLibraryBranchContracts.RequestDto>
{
    public RemoveLibraryBranchRequestValidator()
    {
        RuleFor(x => x.LibraryBranchCode)
            .IsLibraryBranchCode();
    }
}
