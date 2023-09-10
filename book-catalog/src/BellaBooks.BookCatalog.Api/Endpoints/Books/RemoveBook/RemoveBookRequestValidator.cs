using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.RemoveBook;

public class RemoveBookRequestValidator : Validator<RemoveBookDto.Request>
{
    public RemoveBookRequestValidator()
    {
        RuleFor(r => r.BookId)
            .GreaterThan(0);
    }
}
