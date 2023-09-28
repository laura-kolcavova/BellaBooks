using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.RemoveAuthor;

public class RemoveAuthorRequestValidator : Validator<Contracts.Authors.RemoveAuthorContracts.Request>
{
    public RemoveAuthorRequestValidator()
    {
        RuleFor(x => x.AuthorId)
          .GreaterThan(0);
    }
}
