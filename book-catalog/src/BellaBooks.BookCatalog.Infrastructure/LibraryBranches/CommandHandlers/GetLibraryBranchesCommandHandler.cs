using BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryBranches.CommandHandlers;

internal class GetLibraryBranchesCommandHandler : ICommandHandler<
    GetLibraryBranchesCommand, ICollection<LibraryBranchDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetLibraryBranchesCommandHandler> _logger;

    public GetLibraryBranchesCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetLibraryBranchesCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        ICollection<LibraryBranchDetailReadModel>>
        ExecuteAsync(GetLibraryBranchesCommand command, CancellationToken ct)
    {
        try
        {
            var libraryBranches = await _bookCatalogContext.LibraryBranches
                .Select(libraryBranch => LibraryBranchDetailReadModelExtensions.FromEntity(libraryBranch))
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
