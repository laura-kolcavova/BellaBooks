using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

internal class GetAllGenresResponseMapper : ResponseMapper<
    GetAllGenresContracts.ResponseDto,
    ICollection<GenreDetailReadModel>>
{
    public override GetAllGenresContracts.ResponseDto FromEntity(ICollection<GenreDetailReadModel> e)
    {
        return new()
        {
            Genres = e
                .Select(GenreDetailDto.FromEntity)
                .ToList(),
        };
    }
}
