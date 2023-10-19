using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.RemoveAuthor;

internal class RemoveAuthorRequestValidator : Validator<RemoveAuthorContracts.Request>
{
    public RemoveAuthorRequestValidator()
    {
        RuleFor(x => x.AuthorId)
          .IsNumericId();
    }
}
