﻿using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Extensions;
using BellaBooks.BookCatalog.Bussiness.Authors.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Authors.EditGenreInfo;

public class EditAuthorInfoEndpoint : Endpoint<
    EditAuthorInfoDto.Request,
    Results<Ok, ProblemHttpResult>>
{
    public override void Configure()
    {
        Post("EditAuthorInfo");
        Group<AuthorsEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Edits an author info";
            s.Description = "The endpoint will edit an author info";
        });

        Description(d => d
          .Produces<ProblemDetailResponse>(StatusCodes.Status404NotFound)
          .Produces<ProblemDetailResponse>(StatusCodes.Status422UnprocessableEntity));
    }

    public override async Task<
        Results<Ok, ProblemHttpResult>>
        ExecuteAsync(EditAuthorInfoDto.Request req, CancellationToken ct)
    {
        var result = await new EditAuthorInfoCommand
        {
            AuthorId = req.AuthorId,
            Name = req.Name
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