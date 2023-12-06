using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryPrints.CommandHandlers;

internal class RemoveLibraryPrintCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>> Handle(RemoveLibraryPrintCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryPrintId"] = request.LibraryPrintId
        });

        try
        {
            var libraryPrintExists = await _bookCatalogContext.LibraryPrints
                .AnyAsync(libraryPrint => libraryPrint.Id == request.LibraryPrintId, cancellationToken);

            if (!libraryPrintExists)
            {
                return Result.Failure<int, ErrorResult>(
                    LibraryPrintErrorResults.LibraryPrintNotFound);
            }

            var changes = await _bookCatalogContext.LibraryPrints
                .Where(libraryPrint => libraryPrint.Id == request.LibraryPrintId)
                .ExecuteDeleteAsync(cancellationToken);

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
