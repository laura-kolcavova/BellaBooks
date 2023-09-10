using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

public class GetAllGenresResponseMapper : ResponseMapper<
    GetAllGenresDto.Response,
    ICollection<GenreEntity>>
{
    public override GetAllGenresDto.Response FromEntity(ICollection<GenreEntity> e)
    {
        return new()
        {
            Genres = e
                .Select(GenreDto.FromEntity)
                .ToList(),
        };
    }
}
