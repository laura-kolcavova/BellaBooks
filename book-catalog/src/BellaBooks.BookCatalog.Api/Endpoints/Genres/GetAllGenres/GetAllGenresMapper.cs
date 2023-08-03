using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Genres.GetAllGenres;

public class GetAllGenresMapper : ResponseMapper<
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
