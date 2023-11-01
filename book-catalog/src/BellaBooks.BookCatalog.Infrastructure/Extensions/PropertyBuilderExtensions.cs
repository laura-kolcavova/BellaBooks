using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

internal static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> HasStringEnumConversion<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
        where TProperty : Enum
    {
        propertyBuilder.HasConversion(
            enumValue => enumValue.ToString(),
            stringValue => (TProperty)Enum.Parse(typeof(TProperty), stringValue));

        return propertyBuilder;
    }
}
