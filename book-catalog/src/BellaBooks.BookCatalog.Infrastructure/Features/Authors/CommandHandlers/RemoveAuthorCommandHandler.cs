using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Authors;
using BellaBooks.BookCatalog.Application.Features.Authors.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Authors.CommandHandlers;

internal class RemoveAuthorCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>>
        Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = request.AuthorId,
        });

        try
        {
            var authorExists = await _bookCatalogContext.Authors
            .AnyAsync(author => author.Id == request.AuthorId, cancellationToken);

            if (!authorExists)
            {
                return UnitResult.Failure
                    (AuthorErrorResults.AuthorNotFound);
            }

            var changes = await _bookCatalogContext.Authors
            .Where(author => author.Id == request.AuthorId)
                .ExecuteDeleteAsync(cancellationToken);

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
