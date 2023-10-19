using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.RemovePublisher;

internal class RemovePublisherRequestValidator : Validator<RemovePublisherContracts.Request>
{
    public RemovePublisherRequestValidator()
    {
        RuleFor(x => x.PublisherId)
          .IsNumericId();
    }
}
