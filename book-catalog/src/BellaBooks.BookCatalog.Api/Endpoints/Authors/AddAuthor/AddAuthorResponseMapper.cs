using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

public class AddAuthorResponseMapper : ResponseMapper<
    Contracts.Authors.AddAuthorContracts.Response,
    int>
{
    public override Contracts.Authors.AddAuthorContracts.Response FromEntity(int e)
    {
        return new()
        {
            AuthorId = e,
        };
    }
}
