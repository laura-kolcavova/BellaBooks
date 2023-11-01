using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryBranches.CommandHandlers;

internal class RemoveLibraryBranchCommandHandler : ICommandHandler<
    RemoveLibraryBranchCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemoveLibraryBranchCommandHandler> _logger;

    public RemoveLibraryBranchCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemoveLibraryBranchCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(RemoveLibraryBranchCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>()
        {
            ["LibraryBranchCode"] = command.LibraryBranchCode
        });

        try
        {
            var libraryBranchExists = await _bookCatalogContext.LibraryBranches
                .AnyAsync(libraryBranch => libraryBranch.Code == command.LibraryBranchCode, ct);

            if (!libraryBranchExists)
            {
                return UnitResult.Failure<ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            var changes = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == command.LibraryBranchCode)
                .ExecuteDeleteAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A library branch was not removed");

                return UnitResult.Failure
                    (LibraryBranchErrorResults.LibraryBranchNotRemoved);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing a library branch");
            throw;
        }
    }
}
