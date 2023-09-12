using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.EditAuthorInfo;

public class EditAuthorInfoRequestValidator : Validator<EditAuthorInfoDto.Request>
{
    public EditAuthorInfoRequestValidator()
    {
        RuleFor(x => x.AuthorId)
           .GreaterThan(0);

        RuleFor(x => x.Name)
            .MaximumLength(255)

            .NotEmpty();
    }
}
