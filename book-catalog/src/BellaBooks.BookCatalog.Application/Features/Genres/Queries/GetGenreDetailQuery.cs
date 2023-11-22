using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Queries;

public record GetGenreDetailQuery : ICommand<
    GenreDetailReadModel?>
{
    public required int GenreId { get; init; }
}
