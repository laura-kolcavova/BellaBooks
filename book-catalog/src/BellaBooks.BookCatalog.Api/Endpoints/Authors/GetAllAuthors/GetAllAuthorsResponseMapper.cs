using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAllAuthors;

public class GetAllAuthorsResponseMapper : ResponseMapper<
    Contracts.Authors.GetAllAuthorsContracts.Response,
    ICollection<AuthorEntity>>
{
    public override Contracts.Authors.GetAllAuthorsContracts.Response FromEntity(ICollection<AuthorEntity> e)
    {
        return new()
        {
            Authors = e
                .Select(AuthorDetailDto.FromEntity)
                .ToList(),
        };
    }
}
