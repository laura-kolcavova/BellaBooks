﻿using BellaBooks.BookCatalog.Bussiness.Books.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Books.CommandHandlers;

internal class RemoveBookCommandHandler : ICommandHandler<
    RemoveBookCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemoveBookCommandHandler> _logger;

    public RemoveBookCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemoveBookCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(RemoveBookCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["BookId"] = command.BookId,
        });

        try
        {
            var bookExists = await _bookCatalogContext.Books
                .AnyAsync(book => book.Id == command.BookId, ct);

            if (!bookExists)
            {
                return UnitResult.Failure
                    (GeneralErrorResults.EntityNotFound);
            }

            var changes = await _bookCatalogContext.Books
                .Where(book => book.Id == command.BookId)
                .ExecuteDeleteAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A book was not removed from the catalog");

                return UnitResult.Failure
                    (GeneralErrorResults.EntityNotDeleted);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing a book from the catalog");
            throw;
        }
    }
}
