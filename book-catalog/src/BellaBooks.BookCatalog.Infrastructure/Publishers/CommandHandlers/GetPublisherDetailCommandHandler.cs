using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.CommandHandlers;
internal class GetPublisherDetailCommandHandler : ICommandHandler<
    GetPublisherDetailCommand, Result<PublisherEntity, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetPublisherDetailCommandHandler> _logger;

    public GetPublisherDetailCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetPublisherDetailCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<PublisherEntity, ErrorResult>>
        ExecuteAsync(GetPublisherDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = command.PublisherId
        });

        try
        {
            var publisher = await _bookCatalogContext.Publishers
                .AsNoTracking()
                .SingleOrDefaultAsync(publisher => publisher.Id == command.PublisherId, ct);

            if (publisher == null)
            {
                return Result.Failure<PublisherEntity, ErrorResult>
                    (PublisherErrorResults.PublisherNotFound);
            }

            return publisher;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a publisher detail");
            throw;
        }
    }
}
