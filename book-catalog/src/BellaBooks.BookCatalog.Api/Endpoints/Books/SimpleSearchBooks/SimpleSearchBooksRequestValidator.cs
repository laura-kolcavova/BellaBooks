using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.SimpleSearchBooks;

public class SimpleSearchBooksRequestValidator : Validator<
    SimpleSearchBooksDto.Request>
{
    public SimpleSearchBooksRequestValidator()
    {
        RuleFor(x => x.SearchInput)
            .NotEmpty()
            .WithMessage("Search input must not be empty");
    }
}
