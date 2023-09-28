using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.EditGenreInfo;

public class EditGenreInfoRequestValidator : Validator<
    Contracts.Genres.EditGenreInfoContracts.Request>
{
    public EditGenreInfoRequestValidator()
    {
        RuleFor(x => x.GenreId)
           .GreaterThan(0);

        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
