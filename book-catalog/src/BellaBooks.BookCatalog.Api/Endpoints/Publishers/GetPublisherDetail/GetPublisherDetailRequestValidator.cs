using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

internal class GetPublisherDetailRequestValidator : Validator<Contracts.Publishers.GetPublisherDetailContracts.Request>
{
    public GetPublisherDetailRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .IsNumericId();
    }
}
