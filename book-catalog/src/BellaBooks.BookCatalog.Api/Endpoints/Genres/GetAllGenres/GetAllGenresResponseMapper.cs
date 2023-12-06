using BellaBooks.BookCatalog.Api.Contracts.Genres;
using BellaBooks.BookCatalog.Application.Features.Genres.Queries;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Genres.GetAllGenres;

internal class GetAllGenresResponseMapper : ResponseMapper<
    GetAllGenresContracts.ResponseDto,
    IReadOnlyCollection<GenreDetailReadModel>>
{
    public override GetAllGenresContracts.ResponseDto FromEntity(IReadOnlyCollection<GenreDetailReadModel> e)
    {
        return new()
        {
            Genres = e
                .Select(GenreDetailDto.FromEntity)
                .ToList(),
        };
    }
}
