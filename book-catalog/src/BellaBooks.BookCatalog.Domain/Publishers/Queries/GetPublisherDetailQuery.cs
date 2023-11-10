using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Queries;

public record GetPublisherDetailQuery : ICommand<
    PublisherDetailReadModel?>
{
    public required int PublisherId { get; init; }
}
