using BellaBooks.BookCatalog.Api.Contracts.Genres;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.AddGenre;

internal class AddGenreResponseMapper : ResponseMapper<
    AddGenreContracts.ResponseDto, int>
{
    public override AddGenreContracts.ResponseDto FromEntity(int e)
    {
        return new()
        {
            GenreId = e
        };
    }
}
