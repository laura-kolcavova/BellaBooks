using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Queries;

public record GetLibraryBranchDetailQuery : ICommand<
    LibraryBranchDetailReadModel?>
{
    public required string LibraryBranchCode { get; init; }
}
