using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;

public record GetLibraryBranchDetailCommand : ICommand<
    LibraryBranchDetailReadModel?>
{
    public required string LibraryBranchCode { get; init; }
}
