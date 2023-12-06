using BellaBooks.BookCatalog.Application.Features.Authors.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Authors.QueryHandlers;

internal class GetAllAuthorsQueryHandler : IRequestHandler<
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
        Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var authors = await _bookCatalogContext.Authors
                .SelectAuthorDetailReadModel()
                .ToListAsync(cancellationToken);

            return authors;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting all authors");
            throw;
        }
    }
}
