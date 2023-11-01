using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.EditPublisherInfo;

internal class EditPublisherInfoRequestValidator : Validator<EditPublisherInfoContracts.RequestDto>
{
    public EditPublisherInfoRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .IsNumericId();

        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
