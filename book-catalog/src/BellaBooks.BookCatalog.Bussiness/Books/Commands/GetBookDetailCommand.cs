using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Books.Commands;

public record GetBookDetailCommand : ICommand<
    Result<BookEntity, ErrorResult>>
{
    public required int BookId { get; init; }
}
