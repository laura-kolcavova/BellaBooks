using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranchDetail;

internal class GetLibraryBranchDetailResponseMapper : ResponseMapper<
    GetLibraryBranchDetailContracts.ResponseDto, LibraryBranchDetailReadModel?>
{
    public override GetLibraryBranchDetailContracts.ResponseDto FromEntity(LibraryBranchDetailReadModel? e)
    {
        return new()
        {
            LibraryBranch = e is null
                ? null
                : LibraryBranchDetailDto.FromEntity(e),
        };
    }
}
