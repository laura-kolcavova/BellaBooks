using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Commands;

public record EditGenreInfoCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }

    public required string Name { get; init; }
}
