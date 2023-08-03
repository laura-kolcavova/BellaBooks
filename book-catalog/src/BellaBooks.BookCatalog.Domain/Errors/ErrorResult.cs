namespace BellaBooks.BookCatalog.Domain.Errors;

public class ErrorResult
{
    public string Code { get; }

    public string Message { get; }

    public ErrorResultSeverity Severity { get; }

    public ErrorResult(
        string code,
        string message = "",
        ErrorResultSeverity severity = ErrorResultSeverity.Error
    )
    {
        Code = code;
        Message = message;
        Severity = severity;
    }
}
