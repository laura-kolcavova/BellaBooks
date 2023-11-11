using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using CSharpFunctionalExtensions;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class AuthorEntityExtensions
{
    public static IQueryable<AuthorDetailReadModel> SelectAuthorDetailReadModel(this IQueryable<AuthorEntity> authors)
    {
        return authors.
            Select(author => new AuthorDetailReadModel
            {
                Id = author.Id,
                Name = author.Name,
            });
    }
}
