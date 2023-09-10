using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Authors.Commands;

public record RemoveAuthorCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int AuthorId { get; init; }
}
