using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches;
using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;
using BellaBooks.BookCatalog.Domain.Entities.LibraryBranches;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.LibraryBranches.CommandHandlers;

internal class AddLibraryBranchCommandHandler : IRequestHandler<
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

    public async Task<Result<string, ErrorResult>> Handle(AddLibraryBranchCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["LibraryBranchCode"] = request.LibraryBranchCode,
            ["Name"] = request.Name,
        });

        try
        {
            var libraryBranchExists = await _bookCatalogContext.LibraryBranches
                .AnyAsync(libraryBranch => libraryBranch.Code == request.LibraryBranchCode, cancellationToken);

            if (libraryBranchExists)
            {
                return Result.Failure<string, ErrorResult>(
                LibraryBranchErrorResults.LibraryBranchWithSameCodeAlreadyExists);
            }

            var libraryBranch = new LibraryBranchEntity(
                request.LibraryBranchCode, request.Name);

            await _bookCatalogContext.AddAsync(libraryBranch, cancellationToken);

            var changes = await _bookCatalogContext.SaveChangesAsync(cancellationToken);

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
