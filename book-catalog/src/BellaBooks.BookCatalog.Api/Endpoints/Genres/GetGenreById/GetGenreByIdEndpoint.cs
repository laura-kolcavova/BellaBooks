﻿using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.EndpointGroups;
using BellaBooks.BookCatalog.Api.Mappers.Genres;
using BellaBooks.BookCatalog.Bussiness.Genres.Commands;
using BellaBooks.BookCatalog.Domain.Constants;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BellaBooks.BookCatalog.Api.Endpoints.Genres.GetGenreById;

public class GetGenreByIdEndpoint : Endpoint<
    GetGenreByIdDto.Request,
    Results<Ok<GetGenreByIdDto.Respone>, NotFound>,
    GetGenreByIdMapper>
{
    public override void Configure()
    {
        Get("Genre/{genreId}");
        Group<GenresEndpointGroup>();
        AllowAnonymous();

        Summary(s =>
        {
            s.Summary = "Searches for a specific book genre by its Id";
            s.Description = "The endpoint will return a book genre detail";
        });
    }

    public override async Task<Results<
        Ok<GetGenreByIdDto.Respone>, NotFound>>
        ExecuteAsync(GetGenreByIdDto.Request req, CancellationToken ct)
    {
        var result = await new GetGenreByIdCommand()
        {
            GenreId = req.GenreId,
        }.ExecuteAsync(ct);

        if (result.IsFailure)
        {
            return result.Error.Code switch
            {
                GeneralErrorCodes.EntityNotFound or
                _ => TypedResults.NotFound(),
            };
        }

        return TypedResults.Ok(Map.FromEntity(result.Value));
    }
}
