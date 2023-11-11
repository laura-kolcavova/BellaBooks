using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Queries;

public record GetAllAuthorsQuery : ICommand<
    ICollection<AuthorDetailReadModel>>
{
}
