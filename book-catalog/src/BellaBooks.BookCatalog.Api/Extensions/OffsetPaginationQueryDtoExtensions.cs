using BellaBooks.BookCatalog.Api.Contracts.Pagination;
using BellaBooks.BookCatalog.Application.Pagination;

namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class OffsetPaginationQueryDtoExtensions
{
    public static OffsetPaginationFilter ToFilter(this OffsetPaginationQueryDto offsetPaginationQueryDto)
    {
        return new()
        {
            Limit = offsetPaginationQueryDto.Limit ?? 0,
            Offset = offsetPaginationQueryDto.Offset ?? int.MaxValue,
        };
    }
}
