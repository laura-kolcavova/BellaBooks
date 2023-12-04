using BellaBooks.BookCatalog.Api.Configuration;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Api.Filters;
using BellaBooks.BookCatalog.Application.Extensions;
using BellaBooks.BookCatalog.Infrastructure.Authentication;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using MicrosoftProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseDefaultServiceProvider((context, options) =>
    {
        options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
        options.ValidateOnBuild = context.HostingEnvironment.IsDevelopment();
    });

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;

var bookCatalogConnectionString = configuration
    .GetSqlConnectionString(ConfigurationConstants.BookCatalogConnectionStringSectionName);

//services
//    .AddOptions();

services
    .AddHealthChecks()
    .AddSqlServer(bookCatalogConnectionString, name: "BookCatalog_DB", tags: new[] { "readiness" });

services
    .AddEndpointsApiExplorer()
    .SwaggerDocument(options =>
    {
        options.DocumentSettings = s =>
        {
            s.Title = builder.Environment.ApplicationName;
            s.Version = "v1";
        };
        options.ShortSchemaNames = true;
        options.AutoTagPathSegmentIndex = 1;
    });

services
    .AddFastEndpoints();
//.AddHttpExceptions(options =>
//{
//    // Only log the when it has a status code of 500 or higher, or when it not is a HttpException.
//    options.ShouldLogException = exception =>
//    {
//        return (exception is HttpExceptionBase httpException && (int)httpException.StatusCode >= 500)
//            || exception is not HttpExceptionBase;
//    };
//});

var jwtBearedConfiguration = configuration
    .GetConfiguration<JwtBearerConfiguration>(ConfigurationConstants.JwtBearerConfigurationSectionName);

services
    .AddMemoryCache()
    .AddApi()
    .AddApplication()
    .AddInfrastructure(jwtBearedConfiguration)
    .AddDataAccess(bookCatalogConnectionString, builder.Environment.IsDevelopment());

// Build application
var app = builder.Build();

app.UseProblemDetailsExceptionHandler();
//app.UseDefaultExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app
    .UseFastEndpoints(options =>
    {
        options.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
        options.Errors.UseValidationProblemDetails();
        //options.Errors.UseProblemDetails();
        options.Endpoints.RoutePrefix = "api";
        options.Endpoints.ShortNames = true;
        options.Endpoints.Configurator = (ep) =>
        {
            ep.Options(b =>
            {
                b.AddEndpointFilter<OperationCancelledFilter>();
            });

            ep.Description(b =>
            {
                b.ProducesProblemFE<ValidationProblemDetails>(StatusCodes.Status400BadRequest);
                b.ProducesProblemFE<MicrosoftProblemDetails>(StatusCodes.Status500InternalServerError);
            });

            ep.Summary(s =>
            {
                s[StatusCodes.Status400BadRequest] = "Validation error";
                s[StatusCodes.Status401Unauthorized] = "Unauthorized request";
                s[StatusCodes.Status500InternalServerError] = "Internal server error";
            });
        };
    });

app
    .UseSwaggerGen(options =>
    {
        options.Path = ".less-known/api-docs/{documentName}.json";
    },
    uiOptions =>
    {
        uiOptions.DocumentPath = "/.less-known/api-docs/{documentName}.json";
        uiOptions.Path = "/.less-known/api-docs/ui";
    });

app.Run();
