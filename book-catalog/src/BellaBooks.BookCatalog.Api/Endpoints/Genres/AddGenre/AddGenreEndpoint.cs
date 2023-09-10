﻿using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

public class AddGenreEndpoint : Endpoint<
    AddGenreDto.Request,
    Results<Ok<AddGenreDto.Response>, UnprocessableEntity>,
    AddGenreMapper>
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
    }

    public override async Task<
        Results<Ok<AddGenreDto.Response>, UnprocessableEntity>>
        ExecuteAsync(AddGenreDto.Request req, CancellationToken ct)
    {
        var result = await new AddGenreCommand
        {
            Name = req.Name
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityAlreadyExists or
                GeneralErrorCodes.NoChangesInDatabase or
                _ => TypedResults.UnprocessableEntity()
            };
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}