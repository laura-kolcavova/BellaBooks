using BellaBooks.BookCatalog.Api.Contracts.Authors;
using MediatR;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

internal class AddAuthorRequestValidator : Validator<AddAuthorContracts.RequestDto>
{
    public AddAuthorRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
