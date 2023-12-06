using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using MediatR;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

internal class AddPublisherRequestValidator : Validator<AddPublisherContracts.RequestDto>
{
    public AddPublisherRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
