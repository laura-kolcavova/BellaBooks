using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Authors.RemoveAuthor;

public class RemoveAuthorEndpoint : Endpoint<
    RemoveAuthorDto.Request,
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
         .Produces<ProblemDetailResponse>(StatusCodes.Status404NotFound)
         .Produces<ProblemDetailResponse>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemoveAuthorDto.Request req, CancellationToken ct)
    {
        var result = await new RemoveAuthorCommand()
        {
            AuthorId = req.AuthorId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound
                 => TypedResultsExtended.ProblemResponse(
                     result.Error.Message, StatusCodes.Status404NotFound, result.Error.Code),

                _ => TypedResultsExtended.ProblemResponse(
                     result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code)
            };
        }

        return TypedResults.Ok();
    }
}
