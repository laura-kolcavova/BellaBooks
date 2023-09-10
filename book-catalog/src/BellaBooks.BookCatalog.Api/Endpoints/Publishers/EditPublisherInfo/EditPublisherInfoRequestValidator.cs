using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.EditPublisherInfo;

public class EditPublisherInfoRequestValidator : Validator<EditPublisherInfoDto.Request>
{
    public EditPublisherInfoRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .GreaterThan(0);

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
