using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;

namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public record LibraryBranchDetailDto
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public required bool IsActive { get; init; }

    public static LibraryBranchDetailDto FromEntity(LibraryBranchDetailReadModel libraryBranch)
    {
        return new LibraryBranchDetailDto
        {
            Code = libraryBranch.Code,
            Name = libraryBranch.Name,
            IsActive = libraryBranch.IsActive,
        };
    }
}
