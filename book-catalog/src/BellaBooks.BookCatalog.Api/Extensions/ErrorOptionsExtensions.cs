using MediatR;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace BellaBooks.BookCatalog.Api.Extensions;

internal static class ErrorOptionsExtensions
{
    private static Func<List<ValidationFailure>, HttpContext, int, object> ResponseBuilder { get; } =
        (failures, ctx, statusCode) =>
        {
            var validationErrors = failures
                .GroupBy(failure => failure.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group
                        .Select(failure => failure.ErrorMessage)
                        .ToArray());

            var problemDetails = new ValidationProblemDetails(validationErrors)
            {
                Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = statusCode,
                Detail = "Please refer to the errors property for additional details",
                Instance = ctx.Request.Path,
                //Extensions = { { "traceId", ctx.TraceIdentifier } }
            };

            return problemDetails;
        };

    public static void UseValidationProblemDetails(this ErrorOptions errorOptions)
    {
        errorOptions.ResponseBuilder = ResponseBuilder;
        errorOptions.ProducesMetadataType = typeof(ValidationProblemDetails);
    }
}
