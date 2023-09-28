using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailRequestValidator : Validator<
    Contracts.Books.GetBookDetailContracts.Request>
{
    public GetBookDetailRequestValidator()
    {
        RuleFor(x => x.BookId)
            .GreaterThan(0);
    }
}
