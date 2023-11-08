using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Publishers.CommandHandlers;

internal class GetAllPublishersCommandHandler : ICommandHandler<
    GetAllPublishersCommand, ICollection<PublisherDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAllPublishersCommandHandler> _logger;

    public GetAllPublishersCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAllPublishersCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        ICollection<PublisherDetailReadModel>>
        ExecuteAsync(GetAllPublishersCommand command, CancellationToken ct)
    {
        try
        {
            var publishers = await _bookCatalogContext.Publishers
                .Select(publisher => PublisherDetailReadModelExtensions.FromEntity(publisher))
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
