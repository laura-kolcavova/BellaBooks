using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreDetailValidator : Validator<
    GetGenreByIdDto.Request>
{
    public GetGenreDetailValidator()
    {
        RuleFor(x => x.GenreId)
            .NotEmpty();
    }
}
