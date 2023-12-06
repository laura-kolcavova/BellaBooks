using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Genres.Queries;

public record GetAllGenresQuery : IRequest<
    IReadOnlyCollection<GenreDetailReadModel>>
{
}
