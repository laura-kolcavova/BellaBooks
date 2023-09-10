using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public class RemoveGenreCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }
}
