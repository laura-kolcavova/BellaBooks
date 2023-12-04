using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Commands;

public record RemoveAuthorCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int AuthorId { get; init; }
}
