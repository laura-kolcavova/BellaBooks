using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.EditGenreInfo;

public class EditGenreInfoRequestValidator : Validator<
    EditGenreInfoDto.Request>
{
    public EditGenreInfoRequestValidator()
    {
        RuleFor(x => x.GenreId)
           .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
