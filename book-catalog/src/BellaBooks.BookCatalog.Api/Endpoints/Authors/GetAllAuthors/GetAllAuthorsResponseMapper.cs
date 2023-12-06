using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Application.Features.Authors.Queries;
using MediatR;

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
