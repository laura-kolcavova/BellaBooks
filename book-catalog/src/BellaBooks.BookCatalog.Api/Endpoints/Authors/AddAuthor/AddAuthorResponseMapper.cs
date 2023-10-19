using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

internal class AddAuthorResponseMapper : ResponseMapper<
    AddAuthorContracts.ResponseDto, int>
{
    public override AddAuthorContracts.ResponseDto FromEntity(int e)
    {
        return new()
        {
            AuthorId = e,
        };
    }
}
