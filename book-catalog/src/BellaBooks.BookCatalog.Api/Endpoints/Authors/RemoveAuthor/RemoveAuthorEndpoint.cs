using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Authors.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Authors.RemoveAuthor;

public class RemoveAuthorEndpoint : Endpoint<
    RemoveAuthorContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Delete("RemoveAuthor");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Remove an author from the catalog";
            s.Description = "The endpoint will remove an author from the catalog";
        });

        Description(d => d
         .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemoveAuthorContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new RemoveAuthorCommand()
        {
            AuthorId = req.AuthorId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
