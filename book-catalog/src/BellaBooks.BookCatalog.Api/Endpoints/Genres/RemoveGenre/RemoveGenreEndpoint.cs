using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.RemoveGenre;

public class RemoveGenreEndpoint : Endpoint<
    RemoveGenreDto.Request,
    Results<Ok, NotFound, UnprocessableEntity>>
{
    public override void Configure()
    {
        Delete("RemoveGenre");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Remove a book genre from the catalog";
            s.Description = "The endpoint will remove genre from the catalog";
        });
    }

    public override async Task<
        Results<Ok, NotFound, UnprocessableEntity>>
        ExecuteAsync(RemoveGenreDto.Request req, CancellationToken ct)
    {
        var result = await new RemoveGenreCommand()
        {
            GenreId = req.GenreId,
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
