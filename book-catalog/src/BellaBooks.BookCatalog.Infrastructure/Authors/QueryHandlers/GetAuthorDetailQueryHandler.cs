using BellaBooks.BookCatalog.Domain.Authors.Queries;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.QueryHandlers;

internal class GetAuthorDetailQueryHandler : ICommandHandler<
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

    public async Task<
        AuthorDetailReadModel?>
        ExecuteAsync(GetAuthorDetailQuery command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = command.AuthorId
        });

        try
        {
            var author = await _bookCatalogContext.Authors
                .Where(author => author.Id == command.AuthorId)
                .Select(author => AuthorDetailReadModelExtensions.FromEntity(author))
                .SingleOrDefaultAsync(ct);

            return author;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting an author detail");
            throw;
        }
    }
}
