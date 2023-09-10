using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAllAuthors;

public class GetAllAuthorsResponseMapper : ResponseMapper<
    GetAllAuthorsDto.Response,
    ICollection<AuthorEntity>>
{
    public override GetAllAuthorsDto.Response FromEntity(ICollection<AuthorEntity> e)
    {
        return new()
        {
            Authors = e
                .Select(AuthorDto.FromEntity)
                .ToList(),
        };
    }
}
