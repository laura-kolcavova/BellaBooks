using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class ActivateLibraryBranchCommandHandler : ICommandHandler<
    ActivateLibraryBranchCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<ActivateLibraryBranchCommandHandler> _logger;

    public ActivateLibraryBranchCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<ActivateLibraryBranchCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(ActivateLibraryBranchCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryBranchCode"] = command.LibraryBranchCode,
        });

        try
        {
            var libraryBranch = await _bookCatalogContext.LibraryBranches
                .FirstOrDefaultAsync(libraryBranch => libraryBranch.Code == command.LibraryBranchCode, ct);

            if (libraryBranch is null)
            {
                return UnitResult.Failure<ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            if (libraryBranch.IsActive)
            {
                return UnitResult.Success<ErrorResult>();
            }

            libraryBranch.Activate();

            _bookCatalogContext.Update(libraryBranch);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("Library branch was not activated");

                return UnitResult.Failure<ErrorResult>(
                   LibraryBranchErrorResults.LibraryBranchActivatingFailed);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while activating a library branch");
            throw;
        }
    }
}
