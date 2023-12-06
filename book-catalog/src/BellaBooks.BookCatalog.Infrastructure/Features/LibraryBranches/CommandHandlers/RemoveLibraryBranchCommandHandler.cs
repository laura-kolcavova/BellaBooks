using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class RemoveLibraryBranchCommandHandler : IRequestHandler<
    RemoveLibraryBranchCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemoveLibraryBranchCommandHandler> _logger;

    public RemoveLibraryBranchCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemoveLibraryBranchCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorResult>> Handle(RemoveLibraryBranchCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>()
        {
            ["LibraryBranchCode"] = request.LibraryBranchCode
        });

        try
        {
            var libraryBranchExists = await _bookCatalogContext.LibraryBranches
                .AnyAsync(libraryBranch => libraryBranch.Code == request.LibraryBranchCode, cancellationToken);

            if (!libraryBranchExists)
            {
                return UnitResult.Failure<ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            var changes = await _bookCatalogContext.LibraryBranches
                .Where(libraryBranch => libraryBranch.Code == request.LibraryBranchCode)
                .ExecuteDeleteAsync(cancellationToken);

            if (changes == 0)
            {
                _logger.LogError("A library branch was not removed");

                return UnitResult.Failure
                    (LibraryBranchErrorResults.LibraryBranchNotRemoved);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing a library branch");
            throw;
        }
    }
}
