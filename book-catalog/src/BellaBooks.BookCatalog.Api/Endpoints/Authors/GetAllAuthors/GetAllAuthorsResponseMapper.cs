using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAllAuthors;

internal class GetAllAuthorsResponseMapper : ResponseMapper<
    GetAllAuthorsContracts.Response,
    ICollection<AuthorEntity>>
{
    public override GetAllAuthorsContracts.Response FromEntity(ICollection<AuthorEntity> e)
    {
        return new()
        {
            Authors = e
                .Select(AuthorDetailDto.FromEntity)
                .ToList(),
        };
    }
}
