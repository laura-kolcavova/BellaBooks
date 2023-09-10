using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.AddAuthor;

public class AddAuthorRequestValidator : Validator<AddAuthorDto.Request>
{
    public AddAuthorRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
