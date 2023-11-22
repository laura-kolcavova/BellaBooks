using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Commands;

public record EditPublisherInfoCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int PublisherId { get; init; }

    public required string Name { get; init; }
}
