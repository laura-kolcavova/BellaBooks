namespace BellaBooks.BookCatalog.Application.Errors;

public record ErrorResult
{
    private static readonly string EmptyMessage = string.Empty;

    public string Code { get; }

    public string Message { get; }

    public ErrorResultSeverity Severity { get; }

    public ErrorResult(string code, string message, ErrorResultSeverity severity)
    {
        Code = code;
        Message = message;
        Severity = severity;
    }
    public ErrorResult(string code, string message)
        : this(code, message, ErrorResultSeverity.Error)
    {
    }

    public ErrorResult(string code)
        : this(code, EmptyMessage, ErrorResultSeverity.Error)
    {
    }
}
