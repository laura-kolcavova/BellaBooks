using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Books.Commands;

public record RemoveBookCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int BookId { get; init; }
}
