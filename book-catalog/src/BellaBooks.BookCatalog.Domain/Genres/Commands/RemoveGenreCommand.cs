using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Commands;

public record RemoveGenreCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }
}
