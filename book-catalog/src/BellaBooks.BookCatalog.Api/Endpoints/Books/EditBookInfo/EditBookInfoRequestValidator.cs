using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;
using FluentValidation;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.EditBookInfo;

internal class EditBookInfoRequestValidator : Validator<EditBookInfoContracts.Request>
{
    public EditBookInfoRequestValidator()
    {
        RuleFor(x => x.BookId)
            .IsNumericId();

        RuleFor(x => x.Title)
           .MaximumLength(255)
           .NotEmpty();

        RuleFor(request => request.AuthorIds)
            .NotEmpty()
            .ForEach(id => id.IsNumericId());

        RuleFor(request => request.GenreIds)
            .ForEach(id => id.IsNumericId());

        RuleFor(x => x.PublisherId)
            .IsNumericId();

        RuleFor(x => x.Isbn)
            .NotEmpty()
            .Length(13);

        RuleFor(x => x.PublicationCity)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(x => x.PublicationLanguage)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(x => x.PageCount)
            .Must(pageCount => pageCount == null || pageCount > 0);

        RuleFor(x => x.Summary)
            .MaximumLength(500)
            .When(request => !string.IsNullOrEmpty(request.Summary));
    }
}
