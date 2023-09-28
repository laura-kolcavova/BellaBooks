using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

public class GetPublisherDetailRequestValidator : Validator<Contracts.Publishers.GetPublisherDetailContracts.Request>
{
    public GetPublisherDetailRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .GreaterThan(0);
    }
}
