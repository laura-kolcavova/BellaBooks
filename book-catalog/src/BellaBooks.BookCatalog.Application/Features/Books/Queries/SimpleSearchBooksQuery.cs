using BellaBooks.BookCatalog.Application.Pagination;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Books.Queries;

public record SimpleSearchBooksQuery : ICommand<
    IReadOnlyCollection<BookListingItemReadModel>>
{
    public required string? SearchInput { get; init; }

    public required SimpleSearchFilter Filter { get; init; }

    public required OffsetPaginationFilter OffsetPaginationFilter { get; init; }
}
