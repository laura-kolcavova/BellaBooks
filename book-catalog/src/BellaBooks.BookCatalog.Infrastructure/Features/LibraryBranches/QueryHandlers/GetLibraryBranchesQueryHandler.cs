using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.QueryHandlers;

internal class GetLibraryBranchesQueryHandler : IRequestHandler<
    GetLibraryBranchesQuery,
    IReadOnlyCollection<LibraryBranchDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetLibraryBranchesQueryHandler> _logger;

    public GetLibraryBranchesQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetLibraryBranchesQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<LibraryBranchDetailReadModel>> Handle(GetLibraryBranchesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var libraryBranches = await _bookCatalogContext.LibraryBranches
                .SelectLibraryBranchDetailReadModel()
                .ToListAsync(cancellationToken);

            return libraryBranches;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting library branches");
            throw;
        }
    }
}
