namespace BellaBooks.BookCatalog.Domain.Errors;

public class ErrorResult
{
    public required string Code { get; init; }

    public string Message { get; init; } = string.Empty;

    public ErrorResultSeverity Severity { get; init; } = ErrorResultSeverity.Error;
}
