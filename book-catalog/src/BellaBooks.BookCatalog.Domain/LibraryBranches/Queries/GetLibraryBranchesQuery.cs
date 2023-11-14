using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Queries;

public record GetLibraryBranchesQuery : ICommand<
    IReadOnlyCollection<LibraryBranchDetailReadModel>>
{
}
