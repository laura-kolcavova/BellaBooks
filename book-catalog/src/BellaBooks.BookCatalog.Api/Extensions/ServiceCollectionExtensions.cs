namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        return services;
    }

    //public static IServiceCollection AddHttpExceptions(this IServiceCollection services, Action<HttpExceptionsOptions> configureOptions)
    //{
    //    services
    //        .Configure(configureOptions)
    //        .ConfigureOptions<HttpExceptionsOptionsSetup>();

    //    return services;
    //}
}
