using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Genres.CreateGenre;

public class AddGenreValidator : Validator<
    AddGenreDto.Request>
{
    public AddGenreValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
