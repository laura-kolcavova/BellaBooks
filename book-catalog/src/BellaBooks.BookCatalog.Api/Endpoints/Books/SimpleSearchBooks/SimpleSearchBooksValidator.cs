using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.SimpleSearchBooks;

public class SimpleSearchBooksValidator : Validator<
    SimpleSearchBooksDto.Request>
{
    public SimpleSearchBooksValidator()
    {
        RuleFor(x => x.SearchInput)
            .NotEmpty()
            .WithMessage("Search input must not be empty");
    }
}
