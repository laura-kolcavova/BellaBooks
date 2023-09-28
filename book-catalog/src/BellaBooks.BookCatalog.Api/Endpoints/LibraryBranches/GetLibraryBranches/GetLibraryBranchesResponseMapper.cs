using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranches;

public class GetLibraryBranchesResponseMapper : ResponseMapper<
    GetLibraryBranchesContracts.Response, ICollection<LibraryBranchEntity>>
{
    public override GetLibraryBranchesContracts.Response FromEntity(ICollection<LibraryBranchEntity> e)
    {
        return new()
        {
            LibraryBranches = e
                .Select(LibraryBranchDetailDto.FromEntity)
                .ToList(),
        };
    }
}
