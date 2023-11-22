using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;

public record GetLibraryBranchesQuery : ICommand<
    ICollection<LibraryBranchDetailReadModel>>
{
}
