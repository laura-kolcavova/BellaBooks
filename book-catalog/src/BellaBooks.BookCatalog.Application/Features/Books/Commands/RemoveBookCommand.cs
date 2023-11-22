using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Books.Commands;

public record RemoveBookCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int BookId { get; init; }
}
