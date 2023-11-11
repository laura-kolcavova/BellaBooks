using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.Genres.ReadModels;

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
