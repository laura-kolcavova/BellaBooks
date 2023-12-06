using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Queries;

public record GetGenreDetailQuery : IRequest<
    GenreDetailReadModel?>
{
    public required int GenreId { get; init; }
}
