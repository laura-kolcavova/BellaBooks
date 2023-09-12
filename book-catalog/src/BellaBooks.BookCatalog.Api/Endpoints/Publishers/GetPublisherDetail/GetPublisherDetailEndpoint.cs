using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Publishers.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.GetPublisherDetail;

public class GetPublisherDetailEndpoint : Endpoint<
    GetPublisherDetailDto.Request,
    Results<Ok<GetPublisherDetailDto.Response>, ProblemHttpResult>,
    GetPublisherDetailResponseMapper>
{
    public override void Configure()
    {
        Get("GetPublisherDetail/{publisherId}");
        Group<PublishersEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Gets a publisher detail by its Id";
            s.Description = "The endpoint will return a publisher detail";
        });

        Description(d => d
         .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<Results<
        Ok<GetPublisherDetailDto.Response>, ProblemHttpResult>>
        ExecuteAsync(GetPublisherDetailDto.Request req, CancellationToken ct)
    {
        var result = await new GetPublisherDetailCommand()
        {
            PublisherId = req.PublisherId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
