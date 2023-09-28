using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

public class GetAuthorDetailResponseMapper : ResponseMapper<
    Contracts.Authors.GetAuthorDetailContracts.Response,
    AuthorEntity?>
{
    public override Contracts.Authors.GetAuthorDetailContracts.Response FromEntity(AuthorEntity? e)
    {
        return new()
        {
            Author = e == null
                ? null
                : AuthorDetailDto.FromEntity(e)
        };
    }
}
