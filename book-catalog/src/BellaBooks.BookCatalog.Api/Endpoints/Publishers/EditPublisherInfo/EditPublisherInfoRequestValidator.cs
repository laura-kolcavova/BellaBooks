using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.EditPublisherInfo;

public class EditPublisherInfoRequestValidator : Validator<EditPublisherInfoDto.Request>
{
    public EditPublisherInfoRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
