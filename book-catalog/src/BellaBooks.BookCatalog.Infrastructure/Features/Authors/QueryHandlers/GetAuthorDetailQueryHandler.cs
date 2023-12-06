using BellaBooks.BookCatalog.Application.Features.Authors.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Authors.QueryHandlers;

internal class GetAuthorDetailQueryHandler : IRequestHandler<
    GetAuthorDetailQuery, AuthorDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAuthorDetailQueryHandler> _logger;

    public GetAuthorDetailQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAuthorDetailQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<AuthorDetailReadModel?>
        Handle(GetAuthorDetailQuery request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = request.AuthorId
        });

        try
        {
            var author = await _bookCatalogContext.Authors
            .Where(author => author.Id == request.AuthorId)
                .SelectAuthorDetailReadModel()
                .SingleOrDefaultAsync(cancellationToken);

            return author;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting an author detail");
            throw;
        }
    }
}
