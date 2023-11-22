using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Commands;

public record RemoveGenreCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }
}
