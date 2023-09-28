using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreDetailResponseMapper : ResponseMapper<
    Contracts.Genres.GetGenreDetailContracts.Response,
    GenreEntity?>
{
    public override Contracts.Genres.GetGenreDetailContracts.Response FromEntity(GenreEntity? e)
    {
        return new()
        {
            Genre = e == null
                ? null
                : GenreDetailDto.FromEntity(e),
        };
    }
}
