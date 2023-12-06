using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.QueryHandlers;

internal class GetAllGenresQueryHandler : IRequestHandler<
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

    public async Task<IReadOnlyCollection<GenreDetailReadModel>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var genres = await _bookCatalogContext.Genres
                .SelectGenreDetailReadModel()
                .ToListAsync(cancellationToken);

            return genres;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while getting all book genres");
            throw;
        }
    }
}
