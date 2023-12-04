using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;

public record GetLibraryBranchDetailQuery : ICommand<
    LibraryBranchDetailReadModel?>
{
    public required string LibraryBranchCode { get; init; }
}
