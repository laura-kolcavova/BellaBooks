using BellaBooks.BookCatalog.Domain.LibraryBranches.Queries;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryBranches.QueryHandlers;
internal class GetLibraryBranchDetailQueryHandler : ICommandHandler<
    GetLibraryBranchDetailQuery, LibraryBranchDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetLibraryBranchDetailQueryHandler> _logger;

    public GetLibraryBranchDetailQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetLibraryBranchDetailQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        LibraryBranchDetailReadModel?>
        ExecuteAsync(GetLibraryBranchDetailQuery command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibaryBranchCode"] = command.LibraryBranchCode
        });

        try
        {
            var libraryBranch = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == command.LibraryBranchCode)
                .Select(libraryBranch => LibraryBranchDetailReadModelExtensions.FromEntity(libraryBranch))
                .SingleOrDefaultAsync(ct);

            return libraryBranch;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a library branch detail");
            throw;
        }
    }
}
