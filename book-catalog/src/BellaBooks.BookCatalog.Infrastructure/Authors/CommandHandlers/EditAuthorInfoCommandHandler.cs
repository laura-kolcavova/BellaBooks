using BellaBooks.BookCatalog.Domain.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.CommandHandlers;

internal class EditAuthorInfoCommandHandler : ICommandHandler<
    EditAuthorInfoCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<EditAuthorInfoCommandHandler> _logger;

    public EditAuthorInfoCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<EditAuthorInfoCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(EditAuthorInfoCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = command.AuthorId,
            ["Name"] = command.Name,
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
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                    author => author.Name, command.Name), ct);

            if (changes == 0)
            {
                _logger.LogError("An information about author was not updated");

                return UnitResult.Failure
                    (AuthorErrorResults.AuthorInfoNotUpdated);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while editing an author info");
            throw;
        }
    }
}
