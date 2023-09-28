using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Domain.Genres.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreByIdEndpoint : Endpoint<
    GetGenreDetailContracts.Request,
    Ok<GetGenreDetailContracts.Response>,
    GetGenreDetailResponseMapper>
{
    public override void Configure()
    {
        Get("GetGenreDetail/{genreId}");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Gets a book genre detail by its Id";
            s.Description = "The endpoint will return a book genre detail";
        });
    }

    public override async Task<
        Ok<GetGenreDetailContracts.Response>>
        ExecuteAsync(GetGenreDetailContracts.Request req, CancellationToken ct)
    {
        var result = await new GetGenreDetailCommand()
        {
            GenreId = req.GenreId,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
