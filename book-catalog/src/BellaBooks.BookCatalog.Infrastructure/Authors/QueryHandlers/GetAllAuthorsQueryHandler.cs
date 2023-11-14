using BellaBooks.BookCatalog.Domain.Authors.Queries;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.QueryHandlers;

internal class GetAllAuthorsQueryHandler : ICommandHandler<
    GetAllAuthorsQuery,
    IReadOnlyCollection<AuthorDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAllAuthorsQueryHandler> _logger;

    public GetAllAuthorsQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAllAuthorsQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<AuthorDetailReadModel>>
        ExecuteAsync(GetAllAuthorsQuery command, CancellationToken ct)
    {
        try
        {
            var authors = await _bookCatalogContext.Authors
                .SelectAuthorDetailReadModel()
                .ToListAsync(ct);

            return authors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting all authors");
            throw;
        }
    }
}
