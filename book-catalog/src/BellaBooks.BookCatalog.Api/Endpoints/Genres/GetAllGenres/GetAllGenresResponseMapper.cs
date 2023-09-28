using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

public class GetAllGenresResponseMapper : ResponseMapper<
    Contracts.Genres.GetAllGenresContracts.Response,
    ICollection<GenreEntity>>
{
    public override Contracts.Genres.GetAllGenresContracts.Response FromEntity(ICollection<GenreEntity> e)
    {
        return new()
        {
            Genres = e
                .Select(GenreDetailDto.FromEntity)
                .ToList(),
        };
    }
}
