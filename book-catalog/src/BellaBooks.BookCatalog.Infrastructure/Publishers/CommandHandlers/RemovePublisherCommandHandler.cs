using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.CommandHandlers;

internal class RemovePublisherCommandHandler : ICommandHandler<
    RemovePublisherCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemovePublisherCommandHandler> _logger;

    public RemovePublisherCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemovePublisherCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(RemovePublisherCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = command.PublisherId,
        });

        try
        {
            var publisherExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Id == command.PublisherId, ct);

            if (!publisherExists)
            {
                return UnitResult.Failure
                    (PublisherErrorResults.PublisherNotFound);
            }

            var changes = await _bookCatalogContext.Publishers
                .Where(publisher => publisher.Id == command.PublisherId)
                .ExecuteDeleteAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A publisher was not removed from the catalog");

                return UnitResult.Failure
                    (PublisherErrorResults.PublisherNotRemoved);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing a publisher");
            throw;
        }
    }
}
