using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Books.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailEndpoint : Endpoint
    <GetBookDetailDto.Request,
    Results<Ok<GetBookDetailDto.Response>, ProblemHttpResult>,
    GetBookDetailResponseMapper>
{
    public override void Configure()
    {
        Get("GetBookDetail/{bookId}");
        Group<BooksEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Gets a book detail by its Id";
            s.Description = "The endpoint will return a book detail";
        });

        Description(d => d
            .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<Results<
        Ok<GetBookDetailDto.Response>, ProblemHttpResult>>
        ExecuteAsync(GetBookDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetBookDetailCommand
        {
            BookId = req.BookId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
