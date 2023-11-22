using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetAllPublishers;
using BellaBooks.BookCatalog.Application.Features.Publishers.Queries;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.GetAllPublishers;

internal class GetAllPublishersEndpoint : EndpointWithoutRequest<
    Ok<GetAllPublishersContracts.ResponseDto>,
    GetAllPublishersResponseMapper>
{
    public override void Configure()
    {
        Get("GetAllPublishers");
        Group<PublishersEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {

            s.Summary = "Gets collection of all publishers";
            s.Description = "The endpoint will return collection of all publishers";
        });
    }

    public override async Task<
        Ok<GetAllPublishersContracts.ResponseDto>>
        ExecuteAsync(CancellationToken ct)
    {
        var Publishers = await new GetAllPublishersQuery()
            .ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(Publishers));
    }
}
