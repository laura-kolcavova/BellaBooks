using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.RemovePublisher;

public class RemovePublisherEndpoint : Endpoint<
    RemovePublisherContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Delete("RemovePublisher");
        Group<PublishersEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Remove a publisher from the catalog";
            s.Description = "The endpoint will remove a publisher from the catalog";
        });

        Description(d => d
         .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemovePublisherContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new RemovePublisherCommand()
        {
            PublisherId = req.PublisherId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
