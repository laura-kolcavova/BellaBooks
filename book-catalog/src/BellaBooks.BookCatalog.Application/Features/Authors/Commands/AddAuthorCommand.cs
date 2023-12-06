using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Commands;

public record AddAuthorCommand : IRequest<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
