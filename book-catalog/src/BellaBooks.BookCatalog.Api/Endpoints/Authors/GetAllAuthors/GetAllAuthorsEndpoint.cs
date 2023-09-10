using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAllAuthors;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

public class GetAllAuthorsEndpoint : EndpointWithoutRequest<
    Ok<GetAllAuthorsDto.Response>,
    GetAllAuthorsResponseMapper>
{
    public override void Configure()
    {
        Get("GetAllAuthors");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {

            s.Summary = "Gets collection of all authors";
            s.Description = "The endpoint will return collection of all authors";
        });
    }

    public override async Task<
        Ok<GetAllAuthorsDto.Response>>
        ExecuteAsync(CancellationToken ct)
    {
        var authors = await new GetAllAuthorsCommand()
            .ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(authors));
    }
}
