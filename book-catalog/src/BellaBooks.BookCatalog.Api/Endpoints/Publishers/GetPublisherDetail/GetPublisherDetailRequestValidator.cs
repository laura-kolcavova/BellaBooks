using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

public class GetPublisherDetailRequestValidator : Validator<GetPublisherDetailDto.Request>
{
    public GetPublisherDetailRequestValidator()
    {
        RuleFor(x => x.PublisherId)
           .GreaterThan(0);
    }
}
