using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Publishers.QueryHandlers;

internal class GetPublisherDetailQueryHandler : IRequestHandler<
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

    public async Task<PublisherDetailReadModel?> Handle(GetPublisherDetailQuery request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["PublisherId"] = request.PublisherId
        });

        try
        {
            var publisher = await _bookCatalogContext.Publishers
                .Where(publisher => publisher.Id == request.PublisherId)
                .SelectPublisherDetailReadModel()
                .SingleOrDefaultAsync(cancellationToken);

            return publisher;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a publisher detail");
            throw;
        }
    }
}
