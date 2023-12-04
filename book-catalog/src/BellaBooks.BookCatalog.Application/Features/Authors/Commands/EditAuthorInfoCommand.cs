using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Commands;

public record EditAuthorInfoCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int AuthorId { get; init; }

    public required string Name { get; init; }
}
