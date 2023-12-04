using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.QueryHandlers;

internal class GetAllGenresQueryHandler : ICommandHandler<
    GetAllGenresQuery,
    IReadOnlyCollection<GenreDetailReadModel>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAllGenresQueryHandler> _logger;

    public GetAllGenresQueryHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAllGenresQueryHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<GenreDetailReadModel>>
        ExecuteAsync(GetAllGenresQuery command, CancellationToken ct)
    {
        try
        {
            var genres = await _bookCatalogContext.Genres
                .SelectGenreDetailReadModel()
                .ToListAsync(ct);

            return genres;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting all book genres");
            throw;
        }
    }
}
