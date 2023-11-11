using BellaBooks.BookCatalog.Domain.Publishers.Queries;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.QueryHandlers;

internal class GetPublisherDetailQueryHandler : ICommandHandler<
    GetPublisherDetailQuery, PublisherDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetPublisherDetailQueryHandler> _logger;

    public GetPublisherDetailQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetPublisherDetailQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        PublisherDetailReadModel?>
        ExecuteAsync(GetPublisherDetailQuery command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = command.PublisherId
        });

        try
        {
            var publisher = await _bookCatalogContext.Publishers
                .Where(publisher => publisher.Id == command.PublisherId)
                .SelectPublisherDetailReadModel()
                .SingleOrDefaultAsync(ct);

            return publisher;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a publisher detail");
            throw;
        }
    }
}
