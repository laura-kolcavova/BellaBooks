﻿using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreDetailRequestValidator : Validator<
    Contracts.Genres.GetGenreDetailContracts.Request>
{
    public GetGenreDetailRequestValidator()
    {
        RuleFor(x => x.GenreId)
            .GreaterThan(0);
    }
}
