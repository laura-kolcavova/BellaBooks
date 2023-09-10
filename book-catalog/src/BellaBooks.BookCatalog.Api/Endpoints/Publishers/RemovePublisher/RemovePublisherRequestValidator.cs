using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.RemovePublisher;

public class RemovePublisherRequestValidator : Validator<RemovePublisherDto.Request>
{
    public RemovePublisherRequestValidator()
    {
        RuleFor(x => x.PublisherId)
          .GreaterThan(0);
    }
}
