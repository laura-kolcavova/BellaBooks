using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Authors.EditGenreInfo;

public class EditAuthorInfoEndpoint : Endpoint<
    EditAuthorInfoDto.Request,
    Results<Ok, NotFound, UnprocessableEntity>>
{
    public override void Configure()
    {
        Post("EditAuthorInfo");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Edits an author info";
            s.Description = "The endpoint will edit an author info";
        });
    }

    public override async Task<
        Results<Ok, NotFound, UnprocessableEntity>>
        ExecuteAsync(EditAuthorInfoDto.Request req, CancellationToken ct)
    {
        var result = await new EditAuthorInfoCommand
        {
            AuthorId = req.AuthorId,
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
