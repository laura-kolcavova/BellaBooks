using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.RemovePublisher;

public class RemovePublisherEndpoint : Endpoint<
    RemovePublisherDto.Request,
    Results<Ok, NotFound, UnprocessableEntity>>
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
    }

    public override async Task<
        Results<Ok, NotFound, UnprocessableEntity>>
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
                    => TypedResults.NotFound(),

                GeneralErrorCodes.NoChangesInDatabase or
                _ => TypedResults.UnprocessableEntity()
            };
        }

        return TypedResults.Ok();
    }
}
