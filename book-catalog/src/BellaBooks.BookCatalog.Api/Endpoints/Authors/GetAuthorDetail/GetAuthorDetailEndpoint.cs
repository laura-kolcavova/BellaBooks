using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetAuthorDetailEndpoint : Endpoint<
    GetAuthorDetailDto.Request,
    Results<Ok<GetAuthorDetailDto.Response>, NotFound>,
    GetAuthorDetailResponseMapper>
{
    public override void Configure()
    {
        Get("GetAuthorDetail/{authorId}");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Gets an author detail by its Id";
            s.Description = "The endpoint will return an author detail";
        });
    }

    public override async Task<Results<
        Ok<GetAuthorDetailDto.Response>, NotFound>>
        ExecuteAsync(GetAuthorDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetAuthorDetailCommand()
        {
            AuthorId = req.AuthorId,
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
