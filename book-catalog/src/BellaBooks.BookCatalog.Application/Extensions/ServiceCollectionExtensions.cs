using Microsoft.Extensions.DependencyInjection;

namespace BellaBooks.BookCatalog.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
