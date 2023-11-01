using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Commands;

public record GetGenreDetailCommand : ICommand<
    GenreEntity?>
{
    public required int GenreId { get; init; }
}
