using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Authors;
using BellaBooks.BookCatalog.Application.Features.Authors.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Authors.CommandHandlers;

internal class RemoveAuthorCommandHandler : ICommandHandler<
    RemoveAuthorCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemoveAuthorCommandHandler> _logger;

    public RemoveAuthorCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemoveAuthorCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(RemoveAuthorCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = command.AuthorId,
        });

        try
        {
            var authorExists = await _bookCatalogContext.Authors
                .AnyAsync(author => author.Id == command.AuthorId, ct);

            if (!authorExists)
            {
                return UnitResult.Failure
                    (AuthorErrorResults.AuthorNotFound);
            }

            var changes = await _bookCatalogContext.Authors
                .Where(author => author.Id == command.AuthorId)
                .ExecuteDeleteAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("An author was not removed");

                return UnitResult.Failure
                    (AuthorErrorResults.AuthorNotRemoved);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing an author");
            throw;
        }
    }
}
