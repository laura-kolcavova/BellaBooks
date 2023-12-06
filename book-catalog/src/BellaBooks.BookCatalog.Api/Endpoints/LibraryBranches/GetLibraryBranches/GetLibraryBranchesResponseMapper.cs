using BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.LibraryBranches.GetLibraryBranches;

internal class GetLibraryBranchesResponseMapper : ResponseMapper<
    GetLibraryBranchesContracts.ResponseDto,
    IReadOnlyCollection<LibraryBranchDetailReadModel>>
{
    public override GetLibraryBranchesContracts.ResponseDto FromEntity(IReadOnlyCollection<LibraryBranchDetailReadModel> e)
    {
        return new()
        {
            LibraryBranches = e
                .Select(LibraryBranchDetailDto.FromEntity)
                .ToList(),
        };
    }
}
