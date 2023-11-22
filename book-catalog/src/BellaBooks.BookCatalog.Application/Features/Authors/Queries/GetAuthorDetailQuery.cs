using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Queries;

public record GetAuthorDetailQuery : ICommand<
     AuthorDetailReadModel?>
{
    public required int AuthorId { get; init; }
}
