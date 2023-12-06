using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;
using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.GetPublisherDetail;

internal class GetPublisherDetailEndpoint : Endpoint<
    GetPublisherDetailContracts.RequestDto,
    Ok<GetPublisherDetailContracts.ResponseDto>,
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

    public override async Task<
        Ok<GetPublisherDetailContracts.ResponseDto>>
        ExecuteAsync(GetPublisherDetailContracts.RequestDto req, CancellationToken ct)
    {
        var result = await new GetPublisherDetailQuery()
        {
            PublisherId = req.PublisherId,
        }.ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(result));
    }
}
