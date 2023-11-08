using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Books.Commands;

public record GetBookDetailCommand : ICommand<
    BookDetailReadModel?>
{
    public required int BookId { get; init; }
}
