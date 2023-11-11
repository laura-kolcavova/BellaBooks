using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Books.Queries;

public record GetBookDetailQuery : ICommand<
    BookDetailReadModel?>
{
    public required int BookId { get; init; }
}
