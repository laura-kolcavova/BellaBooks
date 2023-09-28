using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Commands;

public record AddPublisherCommand : ICommand<
    Result<int, ErrorResult>>
{
    public required string Name { get; init; }
}
