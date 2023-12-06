using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Books;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints;
using BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Entities.LibraryPrints;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryPrints.CommandHandlers;

internal class AddLibraryPrintCommandHandler : IRequestHandler<
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

    public async Task<Result<int, ErrorResult>> Handle(AddLibraryPrintCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = request.BookId,
            ["LibraryBranchCode"] = request.LibraryBranchCode,
            ["Shelfmark"] = request.Shelfmark,
        });

        try
        {
            var bookExists = await _bookCatalogContext.Books
                .AnyAsync(book => book.Id == request.BookId, cancellationToken);

            if (!bookExists)
            {
                return Result.Failure<int, ErrorResult>(
                    BookErrorResults.BookNotFound);
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

            if (!libraryBranch.IsActive)
            {
                return Result.Failure<int, ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchIsDisabled);
            }

            var libraryPrint = new LibraryPrintEntity(
                request.BookId, request.LibraryBranchCode, request.Shelfmark, LibraryPrintStateCode.AV);

            await _bookCatalogContext.LibraryPrints.AddAsync(libraryPrint, cancellationToken);

            var changes = await _bookCatalogContext.SaveChangesAsync(cancellationToken);

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
