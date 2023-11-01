using BellaBooks.BookCatalog.Domain.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Genres.CommandHandlers;

internal class GetAllGenresCommandHandler : ICommandHandler<
    GetAllGenresCommand,
    ICollection<GenreEntity>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetAllGenresCommandHandler> _logger;

    public GetAllGenresCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetAllGenresCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        ICollection<GenreEntity>>
        ExecuteAsync(GetAllGenresCommand command, CancellationToken ct)
    {
        try
        {
            var genres = await _bookCatalogContext.Genres
                .AsNoTracking()
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
