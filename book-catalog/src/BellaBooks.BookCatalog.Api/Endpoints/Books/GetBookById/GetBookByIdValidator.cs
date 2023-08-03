using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.GetBookById;

public class GetBookByIdValidator : Validator<
    GetBookByIdDto.Request>
{
    public GetBookByIdValidator()
    {
        RuleFor(x => x.BookId)
            .NotEmpty();
    }
}
