using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Genres;
using BellaBooks.BookCatalog.Application.Features.Genres.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.CommandHandlers;

internal class RemoveGenreCommandHandler : IRequestHandler<
    RemoveGenreCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<RemoveGenreCommandHandler> _logger;

    public RemoveGenreCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<RemoveGenreCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<UnitResult<ErrorResult>> Handle(RemoveGenreCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["GenreId"] = request.GenreId,
        });

        try
        {
            var genreExists = await _bookCatalogContext.Genres
                .AnyAsync(genre => genre.Id == request.GenreId, cancellationToken);

            if (!genreExists)
            {
                return UnitResult.Failure
                    (GenreErrorResults.GenreNotFound);
            }

            var changes = await _bookCatalogContext.Genres
                .Where(genre => genre.Id == request.GenreId)
                .ExecuteDeleteAsync(cancellationToken);

            if (changes == 0)
            {
                _logger.LogError("A genre was not removed");

                return UnitResult.Failure
                    (GenreErrorResults.GenreNotRemoved);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while removing a book genre");
            throw;
        }
    }
}
