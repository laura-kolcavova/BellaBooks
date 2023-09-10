using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Extensions;

public static class TypedResultsExtended
{
    public static ProblemHttpResult ProblemResponse(string detail, int statusCode, string errorCode)
    {
        return TypedResults.Problem(new ProblemDetailResponse(detail, statusCode, errorCode));
    }
}