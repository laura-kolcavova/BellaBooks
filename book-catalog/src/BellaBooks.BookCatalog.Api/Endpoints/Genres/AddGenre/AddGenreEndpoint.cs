using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Application.Features.Genres.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

internal class AddGenreEndpoint : Endpoint<
    AddGenreContracts.RequestDto,
    Results<Ok<AddGenreContracts.ResponseDto>, ProblemHttpResult>,
    AddGenreResponseMapper>
{
    public override void Configure()
    {
        Post("AddGenre");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Add a book genre to the catalog";
            s.Description = "The endpoint will add a new genre to the catalog and return its locator";
        });

        Description(d => d
          .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok<AddGenreContracts.ResponseDto>, ProblemHttpResult>>
        ExecuteAsync(AddGenreContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new AddGenreCommand
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
