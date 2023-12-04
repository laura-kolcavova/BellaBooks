using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

internal class GetGenreByIdEndpoint : Endpoint<
    GetGenreDetailContracts.RequestDto,
    Ok<GetGenreDetailContracts.ResponseDto>,
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
        Ok<GetGenreDetailContracts.ResponseDto>>
        ExecuteAsync(GetGenreDetailContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new GetGenreDetailQuery()
        {
            GenreId = req.GenreId,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
