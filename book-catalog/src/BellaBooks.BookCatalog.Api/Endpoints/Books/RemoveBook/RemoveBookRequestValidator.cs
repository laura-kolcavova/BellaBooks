using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Api.Extensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Books.RemoveBook;

internal class RemoveBookRequestValidator : Validator<RemoveBookContracts.RequestDto>
{
    public RemoveBookRequestValidator()
    {
        RuleFor(r => r.BookId)
            .IsNumericId();
    }
}
