using BellaBooks.BookCatalog.Domain.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryBranches.CommandHandlers;

internal class GetLibraryBranchesCommandHandler : ICommandHandler<
    GetLibraryBranchesCommand, ICollection<LibraryBranchEntity>>
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
        ICollection<LibraryBranchEntity>>
        ExecuteAsync(GetLibraryBranchesCommand command, CancellationToken ct)
    {
        try
        {
            var libraryBranches = await _bookCatalogContext.LibraryBranches
                .AsNoTracking()
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
