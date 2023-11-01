using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryPrints.CommandHandlers;

internal class RemoveLibraryPrintCommandHandler : ICommandHandler<
    RemoveLibraryPrintCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemoveLibraryPrintCommandHandler> _logger;

    public RemoveLibraryPrintCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemoveLibraryPrintCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorResult>>
        ExecuteAsync(RemoveLibraryPrintCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryPrintId"] = command.LibraryPrintId
        });

        try
        {
            var libraryPrintExists = await _bookCatalogContext.LibraryPrints
                .AnyAsync(libraryPrint => libraryPrint.Id == command.LibraryPrintId, ct);

            if (!libraryPrintExists)
            {
                return Result.Failure<int, ErrorResult>(
                    LibraryPrintErrorResults.LibraryPrintNotFound);
            }

            var changes = await _bookCatalogContext.LibraryPrints
                .Where(libraryPrint => libraryPrint.Id == command.LibraryPrintId)
                .ExecuteDeleteAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A library print was not removed");

                return UnitResult.Failure
                    (LibraryPrintErrorResults.LibraryPrintNotRemoved);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing a library print");
            throw;
        }
    }
}
