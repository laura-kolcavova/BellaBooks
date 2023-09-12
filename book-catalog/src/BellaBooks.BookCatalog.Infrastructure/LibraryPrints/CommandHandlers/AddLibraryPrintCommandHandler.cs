using BellaBooks.BookCatalog.Bussiness.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.LibraryPrints.CommandHandlers;

internal class AddLibraryPrintCommandHandler : ICommandHandler<
    AddLibraryPrintCommand, Result<int, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddLibraryPrintCommandHandler> _logger;

    public AddLibraryPrintCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddLibraryPrintCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<Result<int, ErrorResult>> ExecuteAsync(AddLibraryPrintCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = command.BookId
        });

        try
        {
            var bookExists = await _bookCatalogContext.Books
                .AnyAsync(book => book.Id == command.BookId, ct);

            if (!bookExists)
            {
                Result.Failure<int, ErrorResult>(
                    BookErrorResults.BookNotFound);
            }

            var libraryPrint = new LibraryPrintEntity(
                command.BookId, command.LibraryBranchCode, command.Shelfmark, LibraryPrintStateCode.AV);

            await _bookCatalogContext.AddAsync(libraryPrint, ct);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A library print was not added");

                return Result.Failure<int, ErrorResult>(
                    LibraryPrintErrorResults.LibraryPrintNotAdded);
            }

            return libraryPrint.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding a library print");
            throw;
        }
    }
}
