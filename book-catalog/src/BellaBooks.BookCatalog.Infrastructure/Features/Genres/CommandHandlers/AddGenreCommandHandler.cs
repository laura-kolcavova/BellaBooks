using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Application.Features.Genres;
using BellaBooks.BookCatalog.Application.Features.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Entities.Genres;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BellaBooks.BookCatalog.Infrastructure.Features.Genres.CommandHandlers;

internal class AddGenreCommandHandler : IRequestHandler<
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

    public async Task<Result<int, ErrorResult>> Handle(AddGenreCommand request, CancellationToken cancellationToken)
    {
        using var loggerScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["Name"] = request.Name
        });

        try
        {
            var genreWithNameExists = await _bookCatalogContext.Genres
                .AnyAsync(genre => genre.Name == request.Name, cancellationToken);

            if (genreWithNameExists)
            {
                return Result.Failure<int, ErrorResult>
                    (GenreErrorResults.GenreWithSameNameAlreadyExists);
            }
            var newGenre = new GenreEntity(request.Name);

            _bookCatalogContext.Genres
                .Add(newGenre);

            var changes = await _bookCatalogContext
                .SaveChangesAsync(cancellationToken);

            if (changes == 0)
            {
                _logger.LogError("A book was not added");

                return Result.Failure<int, ErrorResult>
                    (GenreErrorResults.GenreNotAdded);
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
