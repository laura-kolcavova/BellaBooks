using BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryBranches.CommandHandlers;
internal class GetLibraryBranchDetailCommandHandler : ICommandHandler<
    GetLibraryBranchDetailCommand, LibraryBranchDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetLibraryBranchDetailCommandHandler> _logger;

    public GetLibraryBranchDetailCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetLibraryBranchDetailCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        LibraryBranchDetailReadModel?>
        ExecuteAsync(GetLibraryBranchDetailCommand command, CancellationToken ct)
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
