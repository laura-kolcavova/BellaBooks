using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Authors.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Authors.CommandHandlers;

internal class GetAuthorDetailCommandHandler : ICommandHandler<
    GetAuthorDetailCommand, AuthorEntity?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAuthorDetailCommandHandler> _logger;

    public GetAuthorDetailCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAuthorDetailCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        AuthorEntity?>
        ExecuteAsync(GetAuthorDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AuthorId"] = command.AuthorId
        });

        try
        {
            var author = await _bookCatalogContext.Authors
                .AsNoTracking()
                .SingleOrDefaultAsync(author => author.Id == command.AuthorId, ct);

            return author;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting an author detail");
            throw;
        }
    }
}
