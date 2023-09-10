using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.RemoveGenre;

public class RemoveAuthorEndpoint : Endpoint<
    RemoveAuthorDto.Request,
    Results<Ok, NotFound, UnprocessableEntity>>
{
    public override void Configure()
    {
        Delete("RemoveAuthor");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Remove an author from the catalog";
            s.Description = "The endpoint will remove an author from the catalog";
        });
    }

    public override async Task<
        Results<Ok, NotFound, UnprocessableEntity>>
        ExecuteAsync(RemoveAuthorDto.Request req, CancellationToken ct)
    {
        var result = await new RemoveAuthorCommand()
        {
            AuthorId = req.AuthorId,
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
