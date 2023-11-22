using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Commands;

public record AddAuthorCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
