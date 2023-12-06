using BellaBooks.BookCatalog.Api.Contracts.Authors;
using BellaBooks.BookCatalog.Api.Extensions;
using MediatR;

namespace BellaBooks.BookCatalog.Api.Endpoints.Authors.GetAuthorDetail;

internal class GetAuthorDetailRequestValidator : Validator<GetAuthorDetailContracts.RequestDto>
{
    public GetAuthorDetailRequestValidator()
    {
        RuleFor(x => x.AuthorId)
           .IsNumericId();
    }
}
