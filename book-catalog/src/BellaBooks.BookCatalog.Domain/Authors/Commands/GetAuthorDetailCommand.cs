using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Commands;

public record GetAuthorDetailCommand : ICommand<
     AuthorEntity?>
{
    public required int AuthorId { get; init; }
}
