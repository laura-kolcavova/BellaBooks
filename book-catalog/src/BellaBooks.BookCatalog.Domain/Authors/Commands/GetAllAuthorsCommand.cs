using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Commands;

public record GetAllAuthorsCommand : ICommand<
    ICollection<AuthorDetailReadModel>>
{
}
