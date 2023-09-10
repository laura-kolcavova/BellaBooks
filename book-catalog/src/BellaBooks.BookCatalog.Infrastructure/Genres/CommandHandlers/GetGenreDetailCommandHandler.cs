﻿using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Genres.CommandHandlers;

internal class GetGenreDetailCommandHandler : ICommandHandler<
    GetGenreDetailCommand,
    Result<GenreEntity, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<GetGenreDetailCommandHandler> _logger;

    public GetGenreDetailCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<GetGenreDetailCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<Result<GenreEntity, ErrorResult>> ExecuteAsync(GetGenreDetailCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["GenreId"] = command.GenreId
        });

        try
        {
            var genre = await _bookCatalogContext.Genres
                .AsNoTracking()
                .SingleOrDefaultAsync(genre => genre.Id == command.GenreId, ct);

            if (genre == null)
            {
                return Result.Failure<GenreEntity, ErrorResult>
                    (GeneralErrorResults.EntityNotFound);
            }

            return genre;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected occurred while getting a book detail");
            throw;
        }
    }
}
