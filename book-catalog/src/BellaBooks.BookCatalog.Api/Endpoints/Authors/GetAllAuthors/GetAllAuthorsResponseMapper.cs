using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAllAuthors;

internal class GetAllAuthorsResponseMapper : ResponseMapper<
    GetAllAuthorsContracts.ResponseDto,
    ICollection<AuthorEntity>>
{
    public override GetAllAuthorsContracts.ResponseDto FromEntity(ICollection<AuthorEntity> e)
    {
        return new()
        {
            Authors = e
                .Select(AuthorDetailDto.FromEntity)
                .ToList(),
        };
    }
}
