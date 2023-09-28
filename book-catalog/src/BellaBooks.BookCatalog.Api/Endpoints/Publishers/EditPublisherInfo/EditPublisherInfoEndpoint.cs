﻿using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Publishers.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Publishers.EditPublisherInfo;

public class EditPublisherInfoEndpoint : Endpoint<
    EditPublisherInfoContracts.Request,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("EditPublisherInfo");
        Group<PublishersEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Edits a publisher info";
            s.Description = "The endpoint will edit a publisher info";
        });

        Description(d => d
          .Produces<ErrorProblemDetails>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(EditPublisherInfoContracts.Request req, CancellationToken ct)
    {
        var result = await new EditPublisherInfoCommand
        {
            PublisherId = req.PublisherId,
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return TypedResultsExtended.ErrorProblem(
                result.Error.Message, StatusCodes.Status422UnprocessableEntity, result.Error.Code);
        }

        return TypedResults.Ok();
    }
}
