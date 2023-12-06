using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryPrints.CommandHandlers;

internal class MoveLibraryPrintToPositionCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>> Handle(MoveLibraryPrintToPositionCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryPrintId"] = request.LibraryPrintId,
            ["Shelfmark"] = request.Shelfmark,
            ["LibraryBranchCode"] = request.LibraryBranchCode
        });

        try
        {
            var libraryPrint = await _bookCatalogContext.LibraryPrints
                .SingleOrDefaultAsync(libraryPrint => libraryPrint.Id == request.LibraryPrintId, cancellationToken);

            if (libraryPrint == null)
            {
                return UnitResult.Failure<ErrorResult>(
                    LibraryPrintErrorResults.LibraryPrintNotFound);
            }
            if (libraryPrint.LibraryBranchCode == request.LibraryBranchCode &&
                libraryPrint.Shelfmark == request.Shelfmark)
            {
                return UnitResult.Failure<ErrorResult>(
                   LibraryPrintErrorResults.LibraryPrintLocationIsSameAsNewOne);
            }

            var libraryBranch = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == request.LibraryBranchCode)
                .Select(libraryBranch => new
                {
                    libraryBranch.Code,
                    libraryBranch.IsActive,
                })
                .SingleOrDefaultAsync(cancellationToken);

            if (libraryBranch is null)
            {
                return Result.Failure<int, ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            libraryPrint.MoveToLocation(request.LibraryBranchCode, request.Shelfmark);

            _bookCatalogContext.Update(libraryPrint);

            var changes = await _bookCatalogContext.SaveChangesAsync(cancellationToken);

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
