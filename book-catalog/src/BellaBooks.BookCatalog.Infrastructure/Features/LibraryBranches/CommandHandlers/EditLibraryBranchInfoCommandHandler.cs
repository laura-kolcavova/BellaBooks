using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class EditLibraryBranchInfoCommandHandler : ICommandHandler<
    EditLibraryBranchInfoCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<EditLibraryBranchInfoCommandHandler> _logger;

    public EditLibraryBranchInfoCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<EditLibraryBranchInfoCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorResult>> ExecuteAsync(EditLibraryBranchInfoCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>()
        {
            ["LibraryBranchCode"] = command.LibraryBranchCode,
            ["Name"] = command.Name
        });

        try
        {
            var libraryBranchExists = await _bookCatalogContext.LibraryBranches
               .AnyAsync(libraryBranch => libraryBranch.Code == command.LibraryBranchCode, ct);

            if (!libraryBranchExists)
            {
                return UnitResult.Failure
                    (LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            var changes = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == command.LibraryBranchCode)
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                    libraryBranch => libraryBranch.Name, command.Name), ct);

            if (changes == 0)
            {
                _logger.LogError("An information about library branch was not updated");

                return UnitResult.Failure
                    (LibraryBranchErrorResults.LibraryBranchInfoNotUpdated);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while editing a library branch info");
            throw;
        }
    }
}
