using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Queries;

public record GetAllGenresQuery : ICommand<
    ICollection<GenreDetailReadModel>>
{
}
