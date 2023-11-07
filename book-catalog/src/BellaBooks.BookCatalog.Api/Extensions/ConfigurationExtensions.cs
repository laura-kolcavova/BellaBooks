using BellaBooks.BookCatalog.Api.Configuration;
using Microsoft.Data.SqlClient;

namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class ConfigurationExtensions
{
    public static TOptions GetConfiguration<TOptions>(this IConfiguration configuration, string? sectionName = null)
        where TOptions : class
    {
        return configuration
           .GetRequiredSection(sectionName ?? typeof(TOptions).Name)
           .Get<TOptions>()!;

        //return configuration
        //    .GetSection(sectionName ?? typeof(TOptions).Name)
        //    .Get<TOptions>() ?? throw new InvalidOperationException($"Cannot find section {sectionName ?? typeof(TOptions).Name}");
    }

    public static string GetSqlConnectionString(this IConfiguration configuration, string sectionName, int? connectTimeout = 1)
    {
        if (configuration == null)
        {
            throw new ArgumentNullException("configuration");
        }

        if (string.IsNullOrWhiteSpace(sectionName))
        {
            throw new ArgumentNullException("sectionName");
        }

        var connectionStringAndPasswordSection = configuration.GetConfiguration<ConnectionStringAndPasswordSection>(sectionName);

        var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionStringAndPasswordSection.ConnectionString);

        if (connectTimeout.HasValue && sqlConnectionStringBuilder.ConnectTimeout == 15)
        {
            sqlConnectionStringBuilder.ConnectTimeout = connectTimeout.Value;
        }

        if (!string.IsNullOrWhiteSpace(connectionStringAndPasswordSection.Password))
        {
            sqlConnectionStringBuilder.Password = connectionStringAndPasswordSection.Password;
        }

        return sqlConnectionStringBuilder.ConnectionString;
    }
}
