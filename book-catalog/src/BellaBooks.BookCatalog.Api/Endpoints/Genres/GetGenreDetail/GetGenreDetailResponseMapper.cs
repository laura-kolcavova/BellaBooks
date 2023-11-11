using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetGenreDetail;

internal class GetGenreDetailResponseMapper : ResponseMapper<
    GetGenreDetailContracts.ResponseDto, GenreDetailReadModel?>
{
    public override GetGenreDetailContracts.ResponseDto FromEntity(GenreDetailReadModel? e)
    {
        return new()
        {
            Genre = e == null
                ? null
                : GenreDetailDto.FromEntity(e),
        };
    }
}
