using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.EditGenreInfo;

internal class EditGenreInfoRequestValidator : Validator<EditGenreInfoContracts.RequestDto>
{
    public EditGenreInfoRequestValidator()
    {
        RuleFor(x => x.GenreId)
           .IsNumericId();

        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
