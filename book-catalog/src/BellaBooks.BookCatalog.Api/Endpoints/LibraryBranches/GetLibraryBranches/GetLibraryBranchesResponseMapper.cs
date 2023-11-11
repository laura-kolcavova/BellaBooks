using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranches;

internal class GetLibraryBranchesResponseMapper : ResponseMapper<
    GetLibraryBranchesContracts.ResponseDto, ICollection<LibraryBranchDetailReadModel>>
{
    public override GetLibraryBranchesContracts.ResponseDto FromEntity(ICollection<LibraryBranchDetailReadModel> e)
    {
        return new()
        {
            LibraryBranches = e
                .Select(LibraryBranchDetailDto.FromEntity)
                .ToList(),
        };
    }
}
