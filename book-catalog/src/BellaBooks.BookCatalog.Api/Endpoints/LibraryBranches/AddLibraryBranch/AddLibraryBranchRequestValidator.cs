using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.AddLibraryBranch;

public class AddLibraryBranchRequestValidator : Validator<AddLibraryBranchContracts.RequestDto>
{
    public AddLibraryBranchRequestValidator()
    {
        RuleFor(r => r.LibraryBranchCode)
            .IsLibraryBranchCode();

        RuleFor(r => r.Name)
            .IsLibraryBranchName();
    }
}
