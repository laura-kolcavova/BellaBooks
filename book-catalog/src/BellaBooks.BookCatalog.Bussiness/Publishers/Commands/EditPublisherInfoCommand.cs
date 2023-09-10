using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Publishers.Commands;

public record EditPublisherInfoCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int PublisherId { get; init; }

    public required string Name { get; init; }
}
