using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

internal class GetAuthorDetailResponseMapper : ResponseMapper<
    GetAuthorDetailContracts.ResponseDto, AuthorDetailReadModel?>
{
    public override GetAuthorDetailContracts.ResponseDto FromEntity(AuthorDetailReadModel? e)
    {
        return new()
        {
            Author = e == null
                ? null
                : AuthorDetailDto.FromEntity(e)
        };
    }
}
