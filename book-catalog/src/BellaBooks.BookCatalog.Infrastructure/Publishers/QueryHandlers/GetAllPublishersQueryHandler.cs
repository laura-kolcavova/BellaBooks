using BellaBooks.BookCatalog.Domain.Publishers.Queries;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.QueryHandlers;

internal class GetAllPublishersQueryHandler : ICommandHandler<
    GetAllPublishersQuery, ICollection<PublisherDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAllPublishersQueryHandler> _logger;

    public GetAllPublishersQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAllPublishersQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        ICollection<PublisherDetailReadModel>>
        ExecuteAsync(GetAllPublishersQuery command, CancellationToken ct)
    {
        try
        {
            var publishers = await _bookCatalogContext.Publishers
                .SelectPublisherDetailReadModel()
                .ToListAsync(ct);

            return publishers;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting all publishers");
            throw;
        }
    }
}
