namespace BellaBooks.BookCatalog.Api.Filters;

internal class OperationCancelledFilter : IEndpointFilter
{
    private readonly ILogger<OperationCancelledFilter> _logger;

    public OperationCancelledFilter(
        ILogger<OperationCancelledFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogDebug(ex, "Request was cancelled");

            // Return 499 Client Closed Request
            // https://httpstatuses.com/499
            return Results.StatusCode(499);
        }
    }
}
