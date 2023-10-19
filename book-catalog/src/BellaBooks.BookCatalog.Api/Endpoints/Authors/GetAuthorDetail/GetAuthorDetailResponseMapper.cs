using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

internal class GetAuthorDetailResponseMapper : ResponseMapper<
    GetAuthorDetailContracts.Response, AuthorEntity?>
{
    public override GetAuthorDetailContracts.Response FromEntity(AuthorEntity? e)
    {
        return new()
        {
            Author = e == null
                ? null
                : AuthorDetailDto.FromEntity(e)
        };
    }
}
