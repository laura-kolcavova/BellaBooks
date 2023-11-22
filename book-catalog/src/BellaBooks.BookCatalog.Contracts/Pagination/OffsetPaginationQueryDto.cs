using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Contracts.Pagination;

public record OffsetPaginationQueryDto
{
    [QueryParam]
    public required int? Limit { get; init; }

    [QueryParam]
    public required int? Offset { get; init; }
}
