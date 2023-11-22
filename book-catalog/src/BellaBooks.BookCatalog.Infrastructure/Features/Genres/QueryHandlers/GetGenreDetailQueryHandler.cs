using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.QueryHandlers;

internal class GetGenreDetailQueryHandler : ICommandHandler<
    GetGenreDetailQuery, GenreDetailReadModel?>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetGenreDetailQueryHandler> _logger;

    public GetGenreDetailQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetGenreDetailQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        GenreDetailReadModel?>
        ExecuteAsync(GetGenreDetailQuery command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["GenreId"] = command.GenreId
        });

        try
        {
            var genre = await _bookCatalogContext.Genres
                .Where(genre => genre.Id == command.GenreId)
                .SelectGenreDetailReadModel()
                .SingleOrDefaultAsync(ct);

            return genre;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a book detail");
            throw;
        }
    }
}
