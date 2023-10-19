using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

internal class GetGenreDetailResponseMapper : ResponseMapper<
    GetGenreDetailContracts.ResponseDto, GenreEntity?>
{
    public override GetGenreDetailContracts.ResponseDto FromEntity(GenreEntity? e)
    {
        return new()
        {
            Genre = e == null
                ? null
                : GenreDetailDto.FromEntity(e),
        };
    }
}
