using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Books.Commands;

public record RemoveBookCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required int BookId { get; init; }
}
