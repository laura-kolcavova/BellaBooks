using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranchDetail;

internal class GetLibraryBranchDetailRequestValidator : Validator<GetLibraryBranchDetailContracts.RequestDto>
{
    public GetLibraryBranchDetailRequestValidator()
    {
        RuleFor(x => x.LibraryBranchCode)
         .IsLibraryBranchCode();
    }
}
