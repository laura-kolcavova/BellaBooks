using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

internal class AddAuthorResponseMapper : ResponseMapper<
    AddAuthorContracts.Response, int>
{
    public override AddAuthorContracts.Response FromEntity(int e)
    {
        return new()
        {
            AuthorId = e,
        };
    }
}
