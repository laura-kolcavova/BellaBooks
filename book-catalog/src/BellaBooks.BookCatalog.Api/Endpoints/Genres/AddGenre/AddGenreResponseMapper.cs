using BellaBooks.BookCatalog.Api.Contracts.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

internal class AddGenreResponseMapper : ResponseMapper<
    AddGenreContracts.Response, int>
{
    public override AddGenreContracts.Response FromEntity(int e)
    {
        return new()
        {
            GenreId = e
        };
    }
}
