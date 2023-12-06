using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Publishers;
using BellaBooks.BookCatalog.Application.Features.Publishers.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Publishers.CommandHandlers;

internal class RemovePublisherCommandHandler : IRequestHandler<
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

    public async Task<UnitResult<ErrorResult>> Handle(RemovePublisherCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = request.PublisherId,
        });

        try
        {
            var publisherExists = await _bookCatalogContext.Publishers
                .AnyAsync(publisher => publisher.Id == request.PublisherId, cancellationToken);

            if (!publisherExists)
            {
                return UnitResult.Failure
                    (PublisherErrorResults.PublisherNotFound);
            }

            var changes = await _bookCatalogContext.Publishers
                .Where(publisher => publisher.Id == request.PublisherId)
                .ExecuteDeleteAsync(cancellationToken);

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
