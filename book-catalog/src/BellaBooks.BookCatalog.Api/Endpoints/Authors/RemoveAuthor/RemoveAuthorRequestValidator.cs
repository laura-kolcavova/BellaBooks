using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.RemoveAuthor;

internal class RemoveAuthorRequestValidator : Validator<RemoveAuthorContracts.RequestDto>
{
    public RemoveAuthorRequestValidator()
    {
        RuleFor(x => x.AuthorId)
          .IsNumericId();
    }
}
