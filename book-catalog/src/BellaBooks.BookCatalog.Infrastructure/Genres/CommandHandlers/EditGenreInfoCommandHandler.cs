﻿using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Genres.CommandHandlers;

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
            var genreExists = await _bookCatalogContext.Genres.AnyAsync(genre
              => genre.Id == command.GenreId, ct);

            if (!genreExists)
            {
                return UnitResult.Failure
                    (GeneralErrorResults.EntityNotFound);
            }

            await _bookCatalogContext.Genres
               .ExecuteUpdateAsync(setters => setters.SetProperty(
                   genre => genre.Name, command.Name), ct);

            return UnitResult.Success<ErrorResult>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while updating a book genre");
            throw;
        }
    }
}
