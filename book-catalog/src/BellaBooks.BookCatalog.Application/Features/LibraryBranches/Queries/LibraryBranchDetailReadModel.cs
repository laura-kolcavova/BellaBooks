namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;

public class LibraryBranchDetailReadModel
{
    public required string Code { get; init; }

    public required string Name { get; init; }

    public required bool IsActive { get; init; }
}
