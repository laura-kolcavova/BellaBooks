using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;

public record GetLibraryBranchesQuery : IRequest<
    IReadOnlyCollection<LibraryBranchDetailReadModel>>
{
}
