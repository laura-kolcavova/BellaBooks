using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.CommandHandlers.Genres;

internal class AddGenreCommandHandler : ICommandHandler<
    AddGenreCommand,
    Result<int, ErrorResult>>
{
    private readonly BookCatalogContext _bookCatalogContext;
    private readonly ILogger<AddGenreCommandHandler> _logger;

    public AddGenreCommandHandler(
        BookCatalogContext bookCatalogContext,
        ILogger<AddGenreCommandHandler> logger)
    {
        _bookCatalogContext = bookCatalogContext;
        _logger = logger;
    }

    public async Task<
        Result<int, ErrorResult>>
        ExecuteAsync(AddGenreCommand command, CancellationToken ct)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Name"] = command.Name
        });

        try
        {
            var genreWithNameExists = await _bookCatalogContext.Genres
                .AnyAsync(genre => genre.Name == command.Name, ct);

            if (genreWithNameExists)
            {
                return Result.Failure<int, ErrorResult>
                    (GeneralErrorResults.EntityAlreadyExists);
            }

            var newGenre = new GenreEntity(command.Name);

            _bookCatalogContext.Genres
                .Add(newGenre);

            var changes = await _bookCatalogContext
                 .SaveChangesAsync(ct);

            if (changes == 0)
            {
                _logger.LogError("A book was not added to the catalog");

                return Result.Failure<int, ErrorResult>
                    (GeneralErrorResults.NoChangesInDatabase);
            }

            return newGenre.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while adding a book genre");
            throw;
        }
    }
}
