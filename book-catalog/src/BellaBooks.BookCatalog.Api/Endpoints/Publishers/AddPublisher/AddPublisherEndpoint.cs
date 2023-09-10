using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

public class AddPublisherEndpoint : Endpoint<
    AddPublisherDto.Request,
    Results<Ok<AddPublisherDto.Response>, UnprocessableEntity>,
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
    }

    public override async Task<
        Results<Ok<AddPublisherDto.Response>, UnprocessableEntity>>
        ExecuteAsync(AddPublisherDto.Request req, CancellationToken ct)
    {
        var result = await new AddPublisherCommand
        {
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityAlreadyExists or
                GeneralErrorCodes.NoChangesInDatabase or
                _ => TypedResults.UnprocessableEntity()
            };
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
