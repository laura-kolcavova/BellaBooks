using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

public class AddGenreResponseMapper : ResponseMapper<
    Contracts.Genres.AddGenreContracts.Response,
    int>
{
    public override Contracts.Genres.AddGenreContracts.Response FromEntity(int e)
    {
        return new()
        {
            GenreId = e
        };
    }
}
