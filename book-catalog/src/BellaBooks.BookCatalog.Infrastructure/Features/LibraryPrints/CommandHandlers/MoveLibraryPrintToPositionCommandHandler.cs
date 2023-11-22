using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryPrints.CommandHandlers;

internal class MoveLibraryPrintToPositionCommandHandler : ICommandHandler<
    MoveLibraryPrintToPositionCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<MoveLibraryPrintToPositionCommandHandler> _logger;

    public MoveLibraryPrintToPositionCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<MoveLibraryPrintToPositionCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(MoveLibraryPrintToPositionCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryPrintId"] = command.LibraryPrintId,
            ["Shelfmark"] = command.Shelfmark,
            ["LibraryBranchCode"] = command.LibraryBranchCode
        });

        try
        {
            var libraryPrint = await _bookCatalogContext.LibraryPrints
                .SingleOrDefaultAsync(libraryPrint => libraryPrint.Id == command.LibraryPrintId, ct);

            if (libraryPrint == null)
            {
                return UnitResult.Failure<ErrorResult>(
                    LibraryPrintErrorResults.LibraryPrintNotFound);
            }

            if (libraryPrint.LibraryBranchCode == command.LibraryBranchCode &&
                libraryPrint.Shelfmark == command.Shelfmark)
            {
                return UnitResult.Failure<ErrorResult>(
                   LibraryPrintErrorResults.LibraryPrintLocationIsSameAsNewOne);
            }

            var libraryBranch = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == command.LibraryBranchCode)
                .Select(libraryBranch => new
                {
                    libraryBranch.Code,
                    libraryBranch.IsActive,
                })
                .SingleOrDefaultAsync(ct);

            if (libraryBranch is null)
            {
                return Result.Failure<int, ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            libraryPrint.MoveToLocation(command.LibraryBranchCode, command.Shelfmark);

            _bookCatalogContext.Update(libraryPrint);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("Library print was not moved to location");

                return UnitResult.Failure<ErrorResult>(
                   LibraryPrintErrorResults.LibraryPrintLocationNotChanged);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while moving library print to location");
            throw;
        }
    }
}
