using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

internal class AddPublisherEndpoint : Endpoint<
    AddPublisherContracts.Request,
    Results<Ok<AddPublisherContracts.Response>, ProblemHttpResult>,
    AddPublisherResponseMapper>
{
    public override void Configure()
    {
        Post("AddPublisher");
        Group<PublishersEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Add a new publisher to the catalog";
            s.Description = "The endpoint will add a new publisher to the catalog and return its Id";
        });

        Description(d => d
         .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok<AddPublisherContracts.Response>, ProblemHttpResult>>
        ExecuteAsync(AddPublisherContracts.Request req, CancellationToken ct)
    {
        var result = await new AddPublisherCommand
        {
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
