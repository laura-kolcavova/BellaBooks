using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace FastEndpoints;

internal class ExceptionHandler { }

public static class ExceptionHandlerExtensions
{
    public static IApplicationBuilder UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILogger? logger = null, bool logStructuredException = false)
    {
        app.UseExceptionHandler(errApp =>
        {
            errApp.Run(async ctx =>
            {
                var exHandlerFeature = ctx.Features.Get<IExceptionHandlerFeature>();
                if (exHandlerFeature is not null)
                {
                    logger ??= ctx.Resolve<ILogger<ExceptionHandler>>();
                    var http = exHandlerFeature.Endpoint?.DisplayName?.Split(" => ")[0];
                    var type = exHandlerFeature.Error.GetType().Name;
                    var error = exHandlerFeature.Error.Message;
                    var msg =
$@"================================= 
{http} 
TYPE: {type} 
REASON: {error} 
--------------------------------- 
{exHandlerFeature.Error.StackTrace}";

                    if (logStructuredException)
                        logger.LogError("{@http}{@type}{@reason}{@exception}", http, type, error, exHandlerFeature.Error);
                    else
                        logger.LogError(msg);

                    ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    ctx.Response.ContentType = "application/problem+json";

                    var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails
                    {
                        Type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
                        Title = "Internal Server Error!",
                        Status = ctx.Response.StatusCode,
                        Detail = error,
                        Instance = ctx.Request.Path,
                        //Extensions = { { "traceId", ctx.TraceIdentifier } }
                    };

                    await ctx.Response.WriteAsJsonAsync(problemDetails);
                }
            });
        });

        return app;
    }
}