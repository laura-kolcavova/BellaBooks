﻿using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Genres.UpdateGenre;

public class EditGenreInfoValidator : Validator<
    EditGenreInfoDto.Request>
{
    public EditGenreInfoValidator()
    {
        RuleFor(x => x.GenreId)
           .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
