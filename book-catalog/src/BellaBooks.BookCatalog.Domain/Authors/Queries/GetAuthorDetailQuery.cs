using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Queries;

public record GetAuthorDetailQuery : ICommand<
     AuthorDetailReadModel?>
{
    public required int AuthorId { get; init; }
}
