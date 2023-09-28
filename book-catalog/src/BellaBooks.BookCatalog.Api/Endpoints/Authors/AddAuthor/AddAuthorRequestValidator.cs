using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

public class AddAuthorRequestValidator : Validator<Contracts.Authors.AddAuthorContracts.Request>
{
    public AddAuthorRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
