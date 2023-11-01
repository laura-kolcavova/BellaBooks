using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.AddLibraryBranch;

internal class AddLibraryBranchResponseMapper : ResponseMapper<
    AddLibraryBranchContracts.ResponseDto, string>
{
    public override AddLibraryBranchContracts.ResponseDto FromEntity(string e)
    {
        return new()
        {
            LibraryBranchCode = e
        };
    }
}
