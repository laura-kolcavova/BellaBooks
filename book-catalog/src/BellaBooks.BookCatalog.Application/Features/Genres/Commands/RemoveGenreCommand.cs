using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Commands;

public record RemoveGenreCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required int GenreId { get; init; }
}
