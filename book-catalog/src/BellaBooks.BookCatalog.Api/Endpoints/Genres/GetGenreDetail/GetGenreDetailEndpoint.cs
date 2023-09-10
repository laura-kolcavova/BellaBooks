using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreByIdEndpoint : Endpoint<
    GetGenreDetailDto.Request,
    Results<Ok<GetGenreDetailDto.Response>, ProblemHttpResult>,
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

        Description(d => d
          .Produces<ProblemDetailResponse>(StatusCodes.Status404NotFound));
    }

    public override async Task<Results<
        Ok<GetGenreDetailDto.Response>, ProblemHttpResult>>
        ExecuteAsync(GetGenreDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetGenreDetailCommand()
        {
            GenreId = req.GenreId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            TypedResultsExtended.ProblemResponse(
                result.Error.Message, StatusCodes.Status404NotFound, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
