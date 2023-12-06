using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Commands;

public record EditAuthorInfoCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required int AuthorId { get; init; }

    public required string Name { get; init; }
}
