using LibraNet.BookCatalog.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraNet.BookCatalog.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString, bool isDevelopment)
        {
            services.AddDbContext<BookCatalogContext>((_, options) =>
            {
                options
                    .UseSqlServer(connectionString)
                    .EnableDetailedErrors(isDevelopment)
                    .EnableSensitiveDataLogging(isDevelopment);
            });

            return services;
        }
    }
}
