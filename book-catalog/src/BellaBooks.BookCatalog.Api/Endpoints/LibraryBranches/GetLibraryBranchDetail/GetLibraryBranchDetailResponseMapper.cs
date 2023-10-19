using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranchDetail;

internal class GetLibraryBranchDetailResponseMapper : ResponseMapper<
    GetLibraryBranchDetailContracts.ResponseDto, LibraryBranchEntity?>
{
    public override GetLibraryBranchDetailContracts.ResponseDto FromEntity(LibraryBranchEntity? e)
    {
        return new()
        {
            LibraryBranch = e is null
                ? null
                : LibraryBranchDetailDto.FromEntity(e),
        };
    }
}
