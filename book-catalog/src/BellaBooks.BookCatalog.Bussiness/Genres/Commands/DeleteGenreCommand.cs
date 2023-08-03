using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public class DeleteGenreCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }
}
