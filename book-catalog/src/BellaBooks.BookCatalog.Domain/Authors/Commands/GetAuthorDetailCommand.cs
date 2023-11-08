using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Commands;

public record GetAuthorDetailCommand : ICommand<
     AuthorDetailReadModel?>
{
    public required int AuthorId { get; init; }
}
