using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Authors.Commands;

public record AddAuthorCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
