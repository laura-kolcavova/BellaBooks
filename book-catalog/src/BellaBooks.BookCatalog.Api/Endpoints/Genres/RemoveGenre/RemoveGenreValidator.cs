using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.RemoveGenre;

public class RemoveGenreValidator : Validator<
    RemoveGenreDto.Request>
{
    public RemoveGenreValidator()
    {
        RuleFor(x => x.GenreId)
           .NotEmpty();
    }
}
