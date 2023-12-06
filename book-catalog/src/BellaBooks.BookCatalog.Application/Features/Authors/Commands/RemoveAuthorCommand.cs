using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Commands;

public record RemoveAuthorCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required int AuthorId { get; init; }
}
