using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Genres;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public class GetGenreDetailCommand : ICommand<
    Result<GenreEntity, ErrorResult>>
{
    public required int GenreId { get; init; }
}
