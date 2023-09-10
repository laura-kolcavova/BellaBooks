using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailRequestValidator : Validator<
    GetBookDetailDto.Request>
{
    public GetBookDetailRequestValidator()
    {
        RuleFor(x => x.BookId)
            .NotEmpty();
    }
}
