using BellaBooks.BookCatalog.Domain.LibraryBranches.Queries;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryBranches.QueryHandlers;

internal class GetLibraryBranchesQueryHandler : ICommandHandler<
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

    public async Task<IReadOnlyCollection<LibraryBranchDetailReadModel>>
        ExecuteAsync(GetLibraryBranchesQuery command, CancellationToken ct)
    {
        try
        {
            var libraryBranches = await _bookCatalogContext.LibraryBranches
                .SelectLibraryBranchDetailReadModel()
                .ToListAsync(ct);

            return libraryBranches;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting library branches");
            throw;
        }
    }
}
