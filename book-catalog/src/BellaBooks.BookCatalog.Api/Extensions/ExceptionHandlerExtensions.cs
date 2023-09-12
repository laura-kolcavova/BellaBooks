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
                        Detail = error,
                        Instance = null, // ctx.Request.Path
                        Status = ctx.Response.StatusCode,
                        Title = "Internal Server Error!",
                        Type = type,
                    };

                    await ctx.Response.WriteAsJsonAsync(problemDetails);
                }
            });
        });

        return app;
    }
}