using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Validators.Genres;

public class GetGenreByIdValidator : Validator<
    GetGenreByIdDto.Request>
{
    public GetGenreByIdValidator()
    {
        RuleFor(x => x.GenreId)
            .NotEmpty();
    }
}
