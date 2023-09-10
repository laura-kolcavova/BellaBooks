using BellaBooks.BookCatalog.Api.Contracts.Books;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.AddBook;

public class AddBookRequestValidator : Validator<AddBookDto.Request>
{
    public AddBookRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(request => request.AuthorIds)
            .NotEmpty()
            .ForEach(id => id.GreaterThan(0));

        RuleFor(request => request.GenreIds)
            .NotEmpty()
            .ForEach(id => id.GreaterThan(0));

        RuleFor(x => x.PublisherId)
            .GreaterThan(0);

        RuleFor(x => x.Isbn)
            .NotEmpty()
            .MaximumLength(13);

        RuleFor(x => x.PublicationCity)
            .NotEmpty();

        RuleFor(x => x.PublicationLanguage)
            .NotEmpty();

        RuleFor(x => x.PageCount)
            .Must(pageCount => pageCount == null || pageCount > 0);

        RuleFor(x => x.Summary)
            .MaximumLength(500)
            .When(request => !string.IsNullOrEmpty(request.Summary));
    }
}
