using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Queries;

public record GetGenreDetailQuery : ICommand<
    GenreDetailReadModel?>
{
    public required int GenreId { get; init; }
}
