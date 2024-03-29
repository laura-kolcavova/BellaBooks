﻿using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class DisableLibraryBranchCommandHandler : ICommandHandler<
    DisableLibraryBranchCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<DisableLibraryBranchCommandHandler> _logger;

    public DisableLibraryBranchCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<DisableLibraryBranchCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(DisableLibraryBranchCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryBranchCode"] = command.LibraryBranchCode,
        });

        try
        {
            var libraryBranch = await _bookCatalogContext.LibraryBranches
                .FirstOrDefaultAsync(libraryBranch => libraryBranch.Code == command.LibraryBranchCode, ct);

            if (libraryBranch is null)
            {
                return UnitResult.Failure<ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotFound);
            }

            if (!libraryBranch.IsActive)
            {
                return UnitResult.Success<ErrorResult>();
            }

            libraryBranch.Disable();

            _bookCatalogContext.Update(libraryBranch);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("Library branch was not disabled");

                return UnitResult.Failure<ErrorResult>(
                   LibraryBranchErrorResults.LibraryBranchDisablingFailed);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while deactivating a library branch");
            throw;
        }
    }
}
