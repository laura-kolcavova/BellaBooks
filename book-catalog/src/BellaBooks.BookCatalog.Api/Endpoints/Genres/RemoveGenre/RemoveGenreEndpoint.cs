using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Genres.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.RemoveGenre;

public class RemoveGenreEndpoint : Endpoint<
    RemoveGenreContracts.RequestDto,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Delete("RemoveGenre");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Remove a book genre from the catalog";
            s.Description = "The endpoint will remove genre from the catalog";
        });

        Description(d => d
         .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(RemoveGenreContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new RemoveGenreCommand()
        {
            GenreId = req.GenreId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
