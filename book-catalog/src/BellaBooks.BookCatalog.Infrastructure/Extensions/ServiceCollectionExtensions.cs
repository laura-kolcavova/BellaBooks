using BellaBooks.BookCatalog.Infrastructure.Authentication;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, JwtBearerConfiguration jwtBearerConfiguration)
    {
        var tokenValidationParametres = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtBearerConfiguration.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };

        services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParametres;
            });

        return services;
    }

    public static IServiceCollection AddBookCatalogDataAccess(this IServiceCollection services, string connectionString, bool isDevelopment)
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
