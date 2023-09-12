using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Authors.GetAuthorDetail;

public class GetAuthorDetailEndpoint : Endpoint<
    GetAuthorDetailDto.Request,
    Results<Ok<GetAuthorDetailDto.Response>, ProblemHttpResult>,
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

        Description(d => d
          .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<Results<
        Ok<GetAuthorDetailDto.Response>, ProblemHttpResult>>
        ExecuteAsync(GetAuthorDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetAuthorDetailCommand()
        {
            AuthorId = req.AuthorId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
