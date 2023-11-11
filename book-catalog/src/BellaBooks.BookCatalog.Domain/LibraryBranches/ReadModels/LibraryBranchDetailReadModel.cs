namespace BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;

public class LibraryBranchDetailReadModel
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public required bool IsActive { get; init; }
}
