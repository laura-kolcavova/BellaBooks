using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.EditAuthorInfo;

internal class EditAuthorInfoRequestValidator : Validator<EditAuthorInfoContracts.RequestDto>
{
    public EditAuthorInfoRequestValidator()
    {
        RuleFor(x => x.AuthorId)
           .IsNumericId();

        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
