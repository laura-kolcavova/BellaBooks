using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryPrints.CommandHandlers;

internal class ChangeLibraryPrintStateCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>> Handle(ChangeLibaryPrintStateCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryPrintId"] = request.LibraryPrintId,
            ["StateCode"] = request.StateCode
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

            if (libraryPrint.StateCode == request.StateCode)
            {
                return UnitResult.Failure<ErrorResult>(
                   LibraryPrintErrorResults.LibraryPrintStateIsSameAsNewOne);
            }

            libraryPrint.ChangeState(request.StateCode);

            _bookCatalogContext.Update(libraryPrint);

            var changes = await _bookCatalogContext.SaveChangesAsync(cancellationToken);

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
