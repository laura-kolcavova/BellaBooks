using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreByIdEndpoint : Endpoint<
    GetGenreDetailDto.Request,
    Results<Ok<GetGenreDetailDto.Response>, NotFound>,
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

    public override async Task<Results<
        Ok<GetGenreDetailDto.Response>, NotFound>>
        ExecuteAsync(GetGenreDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetGenreDetailCommand()
        {
            GenreId = req.GenreId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound or
                _ => TypedResults.NotFound(),
            };
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
