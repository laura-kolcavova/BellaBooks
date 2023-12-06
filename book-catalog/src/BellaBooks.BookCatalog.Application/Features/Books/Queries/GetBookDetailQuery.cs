using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Books.Queries;

public record GetBookDetailQuery : IRequest<
    BookDetailReadModel?>
{
    public required int BookId { get; init; }
}
