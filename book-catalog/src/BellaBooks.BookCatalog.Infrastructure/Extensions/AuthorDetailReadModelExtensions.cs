using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class AuthorDetailReadModelExtensions
{
    public static AuthorDetailReadModel FromEntity(AuthorEntity entity)
    {
        return new AuthorDetailReadModel
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
