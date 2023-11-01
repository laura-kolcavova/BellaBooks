using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranches;

internal class GetLibraryBranchesResponseMapper : ResponseMapper<
    GetLibraryBranchesContracts.ResponseDto, ICollection<LibraryBranchEntity>>
{
    public override GetLibraryBranchesContracts.ResponseDto FromEntity(ICollection<LibraryBranchEntity> e)
    {
        return new()
        {
            LibraryBranches = e
                .Select(LibraryBranchDetailDto.FromEntity)
                .ToList(),
        };
    }
}
