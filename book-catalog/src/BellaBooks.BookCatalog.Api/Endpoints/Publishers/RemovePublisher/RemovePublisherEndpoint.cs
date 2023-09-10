using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.RemovePublisher;

public class RemovePublisherEndpoint : Endpoint<
    RemovePublisherDto.Request,
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
         .Produces<ProblemDetailResponse>(StatusCodes.Status404NotFound)
         .Produces<ProblemDetailResponse>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemovePublisherDto.Request req, CancellationToken ct)
    {
        var result = await new RemovePublisherCommand()
        {
            PublisherId = req.PublisherId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound
                 => TypedResultsExtended.ProblemResponse(
                     result.Error.Message, StatusCodes.Status404NotFound, result.Error.Code),

                _ => TypedResultsExtended.ProblemResponse(
                     result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code)
            };
        }

        return TypedResults.Ok();
    }
}
