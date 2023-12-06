using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Commands;

public record AddPublisherCommand : IRequest<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
