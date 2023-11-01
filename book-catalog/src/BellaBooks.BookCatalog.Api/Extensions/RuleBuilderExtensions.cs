using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, int> IsNumericId<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder
            .GreaterThan(0);
    }

    public static IRuleBuilderOptions<T, long> IsNumericId<T>(this IRuleBuilder<T, long> ruleBuilder)
    {
        return ruleBuilder
            .GreaterThan(0);
    }

    public static IRuleBuilderOptions<T, string> IsLibraryBranchCode<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .Length(2);
    }

    public static IRuleBuilderOptions<T, string> IsLibraryBranchName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .MaximumLength(255);
    }
}
