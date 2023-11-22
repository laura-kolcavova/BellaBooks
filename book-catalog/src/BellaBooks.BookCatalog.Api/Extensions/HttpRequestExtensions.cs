using System.Reflection;

namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class HttpRequestExtensions
{
    public static bool HaPropertyOfType<TProperty>(this HttpRequest request, out PropertyInfo? propertyInfo)
    {
        propertyInfo = request
            .GetType()
            .GetProperties()
            .FirstOrDefault(property => property.PropertyType == typeof(TProperty));

        return propertyInfo is not null;
    }

    public static int GetQueryParamNumeric(this HttpRequest request, string key)
    {
        var queryParam = request.Query[key];

        return int.Parse(queryParam.ToString());
    }

    public static int? GetQueryParamNumericOptional(this HttpRequest request, string key)
    {
        if (request.Query.TryGetValue(key, out var queryParam))
        {
            return int.Parse(queryParam.ToString());
        }

        return null;
    }
}
