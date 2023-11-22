using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Queries;

public record GetPublisherDetailQuery : ICommand<
    PublisherDetailReadModel?>
{
    public required int PublisherId { get; init; }
}
