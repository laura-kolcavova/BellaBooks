using BellaBooks.BookCatalog.Application.Pagination;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Books.Queries;

public record SimpleSearchBooksQuery : IRequest<
    IReadOnlyCollection<BookListingItemReadModel>>
{
    public required string? SearchInput { get; init; }

    public required SimpleSearchFilter Filter { get; init; }

    public required OffsetPaginationFilter OffsetPaginationFilter { get; init; }
}
