using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

public class AddGenreRequestValidator : Validator<
    AddGenreDto.Request>
{
    public AddGenreRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
