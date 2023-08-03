using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public class EditGenreInfoCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }

    public required string Name { get; init; }
}
