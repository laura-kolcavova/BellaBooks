using BellaBooks.BookCatalog.Application.Features.Authors.Queries;
using BellaBooks.BookCatalog.Domain.Entities.Authors;
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
