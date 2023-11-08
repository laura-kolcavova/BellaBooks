using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Commands;

public record GetPublisherDetailCommand : ICommand<
    PublisherDetailReadModel?>
{
    public required int PublisherId { get; init; }
}
