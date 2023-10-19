using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

internal class AddGenreRequestValidator : Validator<AddGenreContracts.RequestDto>
{
    public AddGenreRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
