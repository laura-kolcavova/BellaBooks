using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

internal class GetAuthorDetailResponseMapper : ResponseMapper<
    GetAuthorDetailContracts.ResponseDto, AuthorEntity?>
{
    public override GetAuthorDetailContracts.ResponseDto FromEntity(AuthorEntity? e)
    {
        return new()
        {
            Author = e == null
                ? null
                : AuthorDetailDto.FromEntity(e)
        };
    }
}
