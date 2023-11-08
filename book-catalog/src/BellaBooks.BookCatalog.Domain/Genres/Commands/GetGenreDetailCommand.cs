using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Commands;

public record GetGenreDetailCommand : ICommand<
    GenreDetailReadModel?>
{
    public required int GenreId { get; init; }
}
