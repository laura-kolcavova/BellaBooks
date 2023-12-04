using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using BellaBooks.BookCatalog.Domain.Entities.Genres;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class GenreEntityExtensions
{
    public static IQueryable<GenreDetailReadModel> SelectGenreDetailReadModel(this IQueryable<GenreEntity> genres)
    {
        return genres
            .Select(genre => new GenreDetailReadModel
            {
                Id = genre.Id,
                Name = genre.Name,
            });
    }
}
