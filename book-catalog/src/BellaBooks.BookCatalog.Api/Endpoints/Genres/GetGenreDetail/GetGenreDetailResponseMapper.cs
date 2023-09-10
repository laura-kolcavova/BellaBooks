using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

public class GetGenreDetailResponseMapper : ResponseMapper<
    GetGenreDetailDto.Response,
    GenreEntity>
{
    public override GetGenreDetailDto.Response FromEntity(GenreEntity e)
    {
        return new()
        {
            Genre = GenreDto.FromEntity(e),
        };
    }
}
