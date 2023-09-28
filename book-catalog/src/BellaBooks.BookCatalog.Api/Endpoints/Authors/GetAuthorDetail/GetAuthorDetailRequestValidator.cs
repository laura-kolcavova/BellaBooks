using BellaBooks.BookCatalog.Api.Contracts.Authors;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

public class GetAuthorDetailRequestValidator : Validator<Contracts.Authors.GetAuthorDetailContracts.Request>
{
    public GetAuthorDetailRequestValidator()
    {
        RuleFor(x => x.AuthorId)
           .GreaterThan(0);
    }
}
