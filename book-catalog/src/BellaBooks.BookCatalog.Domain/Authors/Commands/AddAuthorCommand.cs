using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Commands;

public record AddAuthorCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
