using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.RemoveGenre;

public class RemoveGenreRequestValidator : Validator<
    Contracts.Genres.RemoveGenreContracts.Request>
{
    public RemoveGenreRequestValidator()
    {
        RuleFor(x => x.GenreId)
           .GreaterThan(0);
    }
}
