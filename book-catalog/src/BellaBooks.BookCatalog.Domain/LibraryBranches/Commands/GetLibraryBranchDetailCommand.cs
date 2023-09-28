using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;

public record GetLibraryBranchDetailCommand : ICommand<
    LibraryBranchEntity?>
{
    public required string LibraryBranchCode { get; init; }
}
