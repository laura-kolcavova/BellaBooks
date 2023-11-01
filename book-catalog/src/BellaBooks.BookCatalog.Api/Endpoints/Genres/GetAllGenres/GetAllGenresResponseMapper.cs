using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

internal class GetAllGenresResponseMapper : ResponseMapper<
    GetAllGenresContracts.ResponseDto,
    ICollection<GenreEntity>>
{
    public override GetAllGenresContracts.ResponseDto FromEntity(ICollection<GenreEntity> e)
    {
        return new()
        {
            Genres = e
                .Select(GenreDetailDto.FromEntity)
                .ToList(),
        };
    }
}
