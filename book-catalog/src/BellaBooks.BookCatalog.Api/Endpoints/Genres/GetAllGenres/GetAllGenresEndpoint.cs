using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

public class GetAllGenresEndpoint : EndpointWithoutRequest<
    Ok<GetAllGenresDto.Response>,
    GetAllGenresResponseMapper>
{
    public override void Configure()
    {
        Get("GetAllGenres");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {

            s.Summary = "Gets collection of all book genres";
            s.Description = "The endpoint will return collection of book genres";
        });
    }

    public override async Task<
        Ok<GetAllGenresDto.Response>>
        ExecuteAsync(CancellationToken ct)
    {
        var genres = await new GetAllGenresCommand()
            .ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(genres));
    }
}
