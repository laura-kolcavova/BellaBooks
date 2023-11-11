using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.Genres.ReadModels;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class GenreDetailReadModelExtensions
{
    public static GenreDetailReadModel FromEntity(GenreEntity entity)
    {
        return new GenreDetailReadModel
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
