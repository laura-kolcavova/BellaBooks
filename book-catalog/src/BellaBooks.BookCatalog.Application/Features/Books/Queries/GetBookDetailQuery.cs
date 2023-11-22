using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Books.Queries;

public record GetBookDetailQuery : ICommand<
    BookDetailReadModel?>
{
    public required int BookId { get; init; }
}
