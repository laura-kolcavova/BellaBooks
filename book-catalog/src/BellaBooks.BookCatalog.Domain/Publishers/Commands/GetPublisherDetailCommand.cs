using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Commands;

public record GetPublisherDetailCommand : ICommand<
    PublisherEntity?>
{
    public required int PublisherId { get; init; }
}
