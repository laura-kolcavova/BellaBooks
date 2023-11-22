namespace BellaBooks.BookCatalog.Application.Pagination;

public record OffsetPaginationFilter
{
    public required int Limit { get; init; }

    public required int Offset { get; init; }
}
