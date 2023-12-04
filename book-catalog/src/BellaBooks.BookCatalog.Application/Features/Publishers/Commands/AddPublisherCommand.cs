using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Commands;

public record AddPublisherCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
