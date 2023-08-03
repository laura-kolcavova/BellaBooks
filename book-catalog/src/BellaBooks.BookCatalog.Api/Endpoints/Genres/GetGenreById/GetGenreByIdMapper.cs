using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Mappers.Genres;

public class GetGenreByIdMapper : Mapper
    <GetGenreByIdDto.Request,
    GetGenreByIdDto.Respone,
    GenreEntity>
{
    public override GetGenreByIdDto.Respone FromEntity(GenreEntity e)
    {
        return new()
        {
            Genre = GenreDto.FromEntity(e),
        };
    }
}
