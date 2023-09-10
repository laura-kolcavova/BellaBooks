using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Authors.Commands;

public record GetAllAuthorsCommand : ICommand<
    ICollection<AuthorEntity>>
{
}
