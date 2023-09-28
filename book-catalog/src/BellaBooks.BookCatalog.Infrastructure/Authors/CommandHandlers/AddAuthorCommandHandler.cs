using BellaBooks.BookCatalog.Domain.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.CommandHandlers;

internal class AddAuthorCommandHandler : ICommandHandler<
    AddAuthorCommand, Result<int, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddAuthorCommandHandler> _logger;

    public AddAuthorCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddAuthorCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<int, ErrorResult>>
        ExecuteAsync(AddAuthorCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Name"] = command.Name
        });

        try
        {
            var authorWithNameAlreadyExists = await _bookCatalogContext.Authors
                .AnyAsync(author => author.Name == command.Name, ct);

            if (authorWithNameAlreadyExists)
            {
                return Result.Failure<int, ErrorResult>
                    (AuthorErrorResults.AuthorWithSameNameAlreadyExists);
            }

            var newAuthor = new AuthorEntity(command.Name);

            _bookCatalogContext.Authors
                .Add(newAuthor);

            var changes = await _bookCatalogContext
                 .SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("An author was not added");

                return Result.Failure<int, ErrorResult>
                    (AuthorErrorResults.AuthorNotAdded);
            }

            return newAuthor.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding an author");
            throw;
        }
    }
}
