using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Genres;
using BellaBooks.BookCatalog.Application.Features.Genres.Commands;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.CommandHandlers;

internal class EditGenreInfoCommandHandler : ICommandHandler<
    EditGenreInfoCommand, UnitResult<ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<EditGenreInfoCommandHandler> _logger;

    public EditGenreInfoCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<EditGenreInfoCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        UnitResult<ErrorResult>>
        ExecuteAsync(EditGenreInfoCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["GenreId"] = command.GenreId,
            ["Name"] = command.Name,
        });

        try
        {
            var changes = await _bookCatalogContext.Genres
                .Where(genre => genre.Id == command.GenreId)
                .ExecuteUpdateAsync(setters => setters.SetProperty(
                    genre => genre.Name, command.Name), ct);

            if (changes == 0)
            {
                _logger.LogError("An information about genre was not updated");

                return UnitResult.Failure
                    (GenreErrorResults.GenreInfoNotUpdated);
            }

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while editing a book genre info");
            throw;
        }
    }
}
