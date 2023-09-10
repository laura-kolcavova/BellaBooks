using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

public class AddAuthorResponseMapper : ResponseMapper<
    AddAuthorDto.Response,
    int>
{
    public override AddAuthorDto.Response FromEntity(int e)
    {
        return new()
        {
            AuthorId = e,
        };
    }
}
