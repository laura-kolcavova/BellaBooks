﻿using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Domain.Authors.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

public class AddAuthorEndpoint : Endpoint<
    AddAuthorContracts.Request,
    Results<Ok<AddAuthorContracts.Response>, ProblemHttpResult>,
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
        Results<Ok<AddAuthorContracts.Response>, ProblemHttpResult>>
        ExecuteAsync(AddAuthorContracts.Request req, CancellationToken ct)
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
