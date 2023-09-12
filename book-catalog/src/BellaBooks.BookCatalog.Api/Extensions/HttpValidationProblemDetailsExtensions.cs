using FluentValidation.Results;

namespace BellaBooks.BookCatalog.Api.Extensions;

public static class HttpValidationProblemDetailsExtensions
{
    public static Func<List<ValidationFailure>, HttpContext, int, object> ResponseBuilder { get; } =
        (failures, ctx, statusCode) =>
        {
            ArgumentNullException.ThrowIfNull(failures);

            var validationErrors = failures
                .GroupBy(failure => failure.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group
                        .Select(failure => failure.ErrorMessage)
                        .ToArray());


            var problemDetails = new HttpValidationProblemDetails(validationErrors)
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = statusCode,
                Detail = "Please refer to the errors property for additional details",
                Instance = ctx.Request.Path,
            };

            return problemDetails;
        };
}
