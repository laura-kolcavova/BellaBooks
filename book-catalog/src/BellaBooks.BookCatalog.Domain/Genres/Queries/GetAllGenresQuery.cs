using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Queries;

public record GetAllGenresQuery : ICommand<
    IReadOnlyCollection<GenreDetailReadModel>>
{
}
