﻿using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

internal class GetAllGenresEndpoint : EndpointWithoutRequest<
    Ok<GetAllGenresContracts.ResponseDto>,
    GetAllGenresResponseMapper>
{
    public override void Configure()
    {
        Get("GetAllGenres");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {

            s.Summary = "Gets collection of all book genres";
            s.Description = "The endpoint will return collection of book genres";
        });
    }

    public override async Task<
        Ok<GetAllGenresContracts.ResponseDto>>
        ExecuteAsync(CancellationToken ct)
    {
        var genres = await new GetAllGenresQuery()
            .ExecuteAsync(ct);

        return TypedResults.Ok(Map.FromEntity(genres));
    }
}
