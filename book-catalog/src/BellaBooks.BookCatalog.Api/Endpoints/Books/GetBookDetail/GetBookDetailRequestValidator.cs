using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

internal class GetBookDetailRequestValidator : Validator<GetBookDetailContracts.RequestDto>
{
    public GetBookDetailRequestValidator()
    {
        RuleFor(x => x.BookId)
            .IsNumericId();
    }
}
