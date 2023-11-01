using BellaBooks.BookCatalog.Domain.Constants;
using FluentAssertions;
using System.Reflection;
using Xunit;

namespace BellaBooks.BookCatalog.UnitTests;

public class ErrorCodeTests
{
    [Fact]
    public void AllErrorCodesAreUnique_Success()
    {
        var errorCodes = GetAllErrorCodes();

        var numberOfUniqueCodes = errorCodes
            .Distinct()
            .Count();

        numberOfUniqueCodes.Should().Be(errorCodes.Count);
    }

    private static IReadOnlyCollection<Type> GetErrorCodeClassTypes()
    {
        var errorCodeClassTypes = new Type[]
        {
            typeof(ErrorCodes.General),
            typeof(ErrorCodes.LibraryBranches),
            typeof(ErrorCodes.Authors),
            typeof(ErrorCodes.Publishers),
            typeof(ErrorCodes.Genres),
            typeof(ErrorCodes.Books),
            typeof(ErrorCodes.LibraryPrints),
        };

        return errorCodeClassTypes;
    }

    private static IReadOnlyCollection<string> GetAllErrorCodes()
    {
        var codes = GetErrorCodeClassTypes()
            .SelectMany(x => GetErrorCodesFromClass(x))
            .ToList();

        return codes;
    }

    private static IReadOnlyCollection<string> GetErrorCodesFromClass(Type errorCodeClassType)
    {
        var fields = errorCodeClassType
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.IsLiteral && x.FieldType == typeof(string));

        var codes = fields
            .Select(field => (string)field.GetValue(null)!)
            .ToList();

        return codes;
    }
}
