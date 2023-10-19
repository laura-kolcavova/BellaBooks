using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.RemoveGenre;

internal class RemoveGenreRequestValidator : Validator<RemoveGenreContracts.Request>
{
    public RemoveGenreRequestValidator()
    {
        RuleFor(x => x.GenreId)
            .IsNumericId();
    }
}
