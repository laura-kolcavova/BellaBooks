using BellaBooks.BookCatalog.Api.Configuration;
using Microsoft.Data.SqlClient;

namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class ConfigurationExtensions
{
    public static T GetConfiguration<T>(this IConfiguration configuration, string sectionName)
    {
        return configuration.GetSection(sectionName).Get<T>() ??
              throw new InvalidOperationException($"Cannot find section {sectionName}");
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
