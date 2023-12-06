using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

internal class GetPublisherDetailRequestValidator : Validator<GetPublisherDetailContracts.RequestDto>
{
    public GetPublisherDetailRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .IsNumericId();
    }
}
