using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

public class AddGenreResponseMapper : ResponseMapper<
    AddGenreDto.Response,
    int>
{
    public override AddGenreDto.Response FromEntity(int e)
    {
        return new()
        {
            GenreId = e
        };
    }
}
