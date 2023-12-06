using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class EditLibraryBranchInfoCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>> Handle(EditLibraryBranchInfoCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>()
        {
            ["LibraryBranchCode"] = request.LibraryBranchCode,
            ["Name"] = request.Name
        });

        try
        {
            var libraryBranchExists = await _bookCatalogContext.LibraryBranches
                .AnyAsync(libraryBranch => libraryBranch.Code == request.LibraryBranchCode, cancellationToken);

            if (!libraryBranchExists)
            {
                return UnitResult.Failure
                    (LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            var changes = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == request.LibraryBranchCode)
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                    libraryBranch => libraryBranch.Name, request.Name), cancellationToken);

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
