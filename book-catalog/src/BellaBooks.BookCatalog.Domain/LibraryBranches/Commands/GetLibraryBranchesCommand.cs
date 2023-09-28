using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;

public record GetLibraryBranchesCommand : ICommand<
    ICollection<LibraryBranchEntity>>
{
}
