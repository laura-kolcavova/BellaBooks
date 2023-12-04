using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Genres;
using BellaBooks.BookCatalog.Application.Features.Genres.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.CommandHandlers;

internal class RemoveGenreCommandHandler : ICommandHandler<
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

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(RemoveGenreCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["GenreId"] = command.GenreId,
        });

        try
        {
            var genreExists = await _bookCatalogContext.Genres
                .AnyAsync(genre => genre.Id == command.GenreId, ct);

            if (!genreExists)
            {
                return UnitResult.Failure
                    (GenreErrorResults.GenreNotFound);
            }

            var changes = await _bookCatalogContext.Genres
                .Where(genre => genre.Id == command.GenreId)
                .ExecuteDeleteAsync(ct);

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
