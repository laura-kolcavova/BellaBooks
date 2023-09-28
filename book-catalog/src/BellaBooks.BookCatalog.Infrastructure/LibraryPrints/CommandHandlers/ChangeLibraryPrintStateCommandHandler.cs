using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryPrints.CommandHandlers;

internal class ChangeLibraryPrintStateCommandHandler : ICommandHandler<
    ChangeLibaryPrintStateCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<ChangeLibraryPrintStateCommandHandler> _logger;

    public ChangeLibraryPrintStateCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<ChangeLibraryPrintStateCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(ChangeLibaryPrintStateCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryPrintId"] = command.LibraryPrintId,
            ["StateCode"] = command.StateCode
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

            if (libraryPrint.StateCode == command.StateCode)
            {
                return UnitResult.Failure<ErrorResult>(
                   LibraryPrintErrorResults.LibraryPrintStateIsSameAsNewOne);
            }

            libraryPrint.ChangeState(command.StateCode);

            _bookCatalogContext.Update(libraryPrint);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("Library print state was not changed");

                return UnitResult.Failure<ErrorResult>(
                   LibraryPrintErrorResults.LibraryPrintStateNotChanged);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while changing library print state");
            throw;
        }
    }
}
