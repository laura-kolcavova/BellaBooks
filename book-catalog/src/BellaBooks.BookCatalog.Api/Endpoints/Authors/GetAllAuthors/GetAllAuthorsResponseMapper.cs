using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAllAuthors;

internal class GetAllAuthorsResponseMapper : ResponseMapper<
    GetAllAuthorsContracts.ResponseDto,
    IReadOnlyCollection<AuthorDetailReadModel>>
{
    public override GetAllAuthorsContracts.ResponseDto FromEntity(IReadOnlyCollection<AuthorDetailReadModel> e)
    {
        return new()
        {
            Authors = e
                .Select(AuthorDetailDto.FromEntity)
                .ToList(),
        };
    }
}
