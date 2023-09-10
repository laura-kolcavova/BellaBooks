using BellaBooks.BookCatalog.Domain.Errors;
using BellaBooks.BookCatalog.Domain.Publishers;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Publishers.Commands;

public record GetPublisherDetailCommand : ICommand<
    Result<PublisherEntity, ErrorResult>>
{
    public required int PublisherId { get; init; }
}
