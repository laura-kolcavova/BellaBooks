using BellaBooks.BookCatalog.Api.Contracts.Pagination;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.RequestBinders;

internal class OffsetPaginationRequestBinder<TRequest> : RequestBinder<TRequest>
    where TRequest : notnull, new()
{
    public async override ValueTask<TRequest> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var httpRequest = ctx.HttpContext.Request;
        var request = await base.BindAsync(ctx, ct);

        if (httpRequest.HaPropertyOfType<OffsetPaginationQueryDto>(out var offsetPaginationQueryDtoProperty))
        {

            var offsetPaginationQueryDto = new OffsetPaginationQueryDto
            {
                Limit = httpRequest.GetQueryParamNumericOptional(nameof(OffsetPaginationQueryDto.Limit)),
                Offset = httpRequest.GetQueryParamNumericOptional(nameof(OffsetPaginationQueryDto.Offset))
            };

            offsetPaginationQueryDtoProperty!.SetValue(request, offsetPaginationQueryDto);
        }

        return request;
    }
}
