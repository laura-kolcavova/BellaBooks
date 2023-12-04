using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Domain.Entities.LibraryBranches;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class AddLibraryBranchCommandHandler : ICommandHandler<
    AddLibraryBranchCommand, Result<string, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddLibraryBranchCommandHandler> _logger;

    public AddLibraryBranchCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddLibraryBranchCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<string, ErrorResult>>
        ExecuteAsync(AddLibraryBranchCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryBranchCode"] = command.LibraryBranchCode,
            ["Name"] = command.Name,
        });

        try
        {
            var libraryBranchExists = await _bookCatalogContext.LibraryBranches
                .AnyAsync(libraryBranch => libraryBranch.Code == command.LibraryBranchCode, ct);

            if (libraryBranchExists)
            {
                return Result.Failure<string, ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchWithSameCodeAlreadyExists);
            }

            var libraryBranch = new LibraryBranchEntity(
                command.LibraryBranchCode, command.Name);

            await _bookCatalogContext.AddAsync(libraryBranch, ct);

            var changes = await _bookCatalogContext.SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A library branch was not added");

                return Result.Failure<string, ErrorResult>(
                    LibraryBranchErrorResults.LibraryBranchNotAdded);
            }

            return libraryBranch.Code;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding a library branch");
            throw;
        }
    }
}
