using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.CommandHandlers;

internal class GetPublisherDetailCommandHandler : ICommandHandler<
    GetPublisherDetailCommand, PublisherDetailReadModel?>
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
        PublisherDetailReadModel?>
        ExecuteAsync(GetPublisherDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = command.PublisherId
        });

        try
        {
            var publisher = await _bookCatalogContext.Publishers
                .Where(publisher => publisher.Id == command.PublisherId)
                .Select(publisher => PublisherDetailReadModelExtensions.FromEntity(publisher))
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
