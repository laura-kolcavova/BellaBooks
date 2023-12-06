using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.RemovePublisher;

internal class RemovePublisherRequestValidator : Validator<RemovePublisherContracts.RequestDto>
{
    public RemovePublisherRequestValidator()
    {
        RuleFor(x => x.PublisherId)
          .IsNumericId();
    }
}
