using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailValidator : Validator<
    GetBookDetailDto.Request>
{
    public GetBookDetailValidator()
    {
        RuleFor(x => x.BookId)
            .NotEmpty();
    }
}
