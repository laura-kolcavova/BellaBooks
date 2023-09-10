using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Publishers.Commands;

public record RemovePublisherCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int PublisherId { get; init; }
}
