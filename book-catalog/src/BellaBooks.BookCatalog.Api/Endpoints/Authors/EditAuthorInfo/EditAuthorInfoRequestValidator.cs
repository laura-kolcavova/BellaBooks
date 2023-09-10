using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.EditAuthorInfo;

public class EditAuthorInfoRequestValidator : Validator<EditAuthorInfoDto.Request>
{
    public EditAuthorInfoRequestValidator()
    {
        RuleFor(x => x.AuthorId)
           .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
