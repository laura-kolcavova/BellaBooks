using Microsoft.AspNetCore.Mvc;

namespace BellaBooks.BookCatalog.Api;

internal class ErrorProblemDetails : ProblemDetails
{
    public ErrorProblemDetails(string detail, int statusCode, string errorCode)
    {
        Detail = detail;
        Status = statusCode;
        Extensions.Add("ErrorCode", errorCode);
    }
}