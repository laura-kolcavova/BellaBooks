using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Publishers;
using FluentAssertions;
using System.Reflection;
using Xunit;

namespace BellaBooks.BookCatalog.UnitTests;

public class ErrorFactoryTests
{
    [Fact]
    public void AllErrorCodesFromErrorFactoriesAreUnique_Success()
    {
        var allErrorCodes = GetAllErrorCodes();

        var numberOfUniqueCodes = allErrorCodes
            .Distinct()
            .Count();

        numberOfUniqueCodes.Should().Be(allErrorCodes.Count);
    }

    private static IReadOnlyCollection<Type> GetErrorFactoryClassTypes()
    {
        var errorFactoryClasses = new Type[]
        {
            typeof(GeneralErrorResults),
            typeof(LibraryBranchErrorResults),
            typeof(AuthorErrorResults),
            typeof(PublisherErrorResults),
            typeof(GenreErrorResults),
            typeof(BookErrorResults),
            typeof(LibraryPrintErrorResults),
        };

        return errorFactoryClasses;
    }

    private static IReadOnlyCollection<string> GetAllErrorCodes()
    {
        var codes = GetErrorFactoryClassTypes()
            .SelectMany(x => GetErrorCodesFromErrorFactory(x))
            .ToList();

        return codes;
    }

    private static IReadOnlyCollection<string> GetErrorCodesFromErrorFactory(Type errorFactoryClassType)
    {
        var methods = errorFactoryClassType
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(x => x.ReturnType == typeof(ErrorResult))
            .ToList();

        var codes = methods
            .Select(x => GetErrorCodeFromMethod(x))
            .ToList();

        return codes;
    }

    private static string GetErrorCodeFromMethod(MethodInfo method)
    {
        var parameters = method
            .GetParameters()
            .Select(x => x.DefaultValue)
            .ToArray();

        var error = (ErrorResult)method.Invoke(null, parameters)!;
        return error.Code;
    }
}
