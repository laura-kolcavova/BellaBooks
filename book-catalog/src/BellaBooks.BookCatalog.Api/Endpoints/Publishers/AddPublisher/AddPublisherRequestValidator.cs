using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.AddPublisher;

public class AddPublisherRequestValidator : Validator<Contracts.Publishers.AddPublisherContracts.Request>
{
    public AddPublisherRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(255)
            .NotEmpty();
    }
}
