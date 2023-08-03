using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Genres.UpdateGenre;

public class EditGenreInfoEndpoint : Endpoint<
    EditGenreInfoDto.Request,
    Results<Ok, UnprocessableEntity>>
{
    public override void Configure()
    {
        Post("EditGennreInfo");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Updates a book genre";
            s.Description = "The endpoint will update a book genre";
        });
    }

    public override async Task<
        Results<Ok, UnprocessableEntity>>
        ExecuteAsync(EditGenreInfoDto.Request req, CancellationToken ct)
    {
        var result = await new EditGenreInfoCommand
        {
            GenreId = req.GenreId,
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound or
                _ => TypedResults.UnprocessableEntity()
            };
        }

        return TypedResults.Ok();
    }
}
