using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

internal class GetGenreDetailRequestValidator : Validator<GetGenreDetailContracts.RequestDto>
{
    public GetGenreDetailRequestValidator()
    {
        RuleFor(x => x.GenreId)
            .IsNumericId();
    }
}
