using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;

public record GetLibraryBranchDetailQuery : IRequest<
    LibraryBranchDetailReadModel?>
{
    public required string LibraryBranchCode { get; init; }
}
