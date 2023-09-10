using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

public class GetAuthorDetailResponseMapper : ResponseMapper<
    GetAuthorDetailDto.Response,
    AuthorEntity>
{
    public override GetAuthorDetailDto.Response FromEntity(AuthorEntity e)
    {
        return new()
        {
            Author = AuthorDto.FromEntity(e),
        };
    }
}
