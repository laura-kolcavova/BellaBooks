using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Extensions;

public static class TypedResultsExtended
{
    public static ProblemHttpResult ErrorProblem(string detail, int statusCode, string errorCode)
    {
        return TypedResults.Problem(new ErrorProblemDetails(detail, statusCode, errorCode));
    }
}