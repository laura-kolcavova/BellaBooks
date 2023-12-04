using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.Authors.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

internal class AddAuthorEndpoint : Endpoint<
    AddAuthorContracts.RequestDto,
    Results<Ok<AddAuthorContracts.ResponseDto>, ProblemHttpResult>,
    AddAuthorResponseMapper>
{
    public override void Configure()
    {
        Post("AddAuthor");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Add a new author to the catalog";
            s.Description = "The endpoint will add a new author to the catalog and return its Id";
        });

        Description(d => d
           .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok<AddAuthorContracts.ResponseDto>, ProblemHttpResult>>
        ExecuteAsync(AddAuthorContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new AddAuthorCommand
        {
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
