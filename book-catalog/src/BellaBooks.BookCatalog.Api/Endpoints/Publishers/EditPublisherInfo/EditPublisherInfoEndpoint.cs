using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.EditPublisherInfo;

public class EditPublisherInfoEndpoint : Endpoint<
    EditPublisherInfoDto.Request,
    Results<Ok, NotFound, UnprocessableEntity>>
{
    public override void Configure()
    {
        Post("EditPublisherInfo");
        Group<PublishersEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Edits a publisher info";
            s.Description = "The endpoint will edit a publisher info";
        });
    }

    public override async Task<
        Results<Ok, NotFound, UnprocessableEntity>>
        ExecuteAsync(EditPublisherInfoDto.Request req, CancellationToken ct)
    {
        var result = await new EditPublisherInfoCommand
        {
            PublisherId = req.PublisherId,
            Name = req.Name
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
