using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Books.Commands;

public record GetBookDetailCommand : ICommand<
    BookEntity?>
{
    public required int BookId { get; init; }
}
