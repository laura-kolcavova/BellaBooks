using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;
using BellaBooks.BookCatalog.Domain.Authors.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Authors.GetAuthorDetail;

public class GetAuthorDetailEndpoint : Endpoint<
    GetAuthorDetailContracts.Request,
    Ok<GetAuthorDetailContracts.Response>,
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

    public override async Task<
        Ok<GetAuthorDetailContracts.Response>>
        ExecuteAsync(GetAuthorDetailContracts.Request req, CancellationToken ct)
    {
        var result = await new GetAuthorDetailCommand()
        {
            AuthorId = req.AuthorId,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
