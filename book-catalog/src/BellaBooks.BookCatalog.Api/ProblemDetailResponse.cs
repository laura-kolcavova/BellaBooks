using Microsoft.AspNetCore.Mvc;

namespace BellaBooks.BookCatalog.Api;

public class ProblemDetailResponse : ProblemDetails
{
    public ProblemDetailResponse(string detail, int statusCode, string errorCode)
    {
        Detail = detail;
        Status = statusCode;
        Extensions.Add("ErrorCode", errorCode);
    }
}