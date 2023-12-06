using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Queries;

public record GetPublisherDetailQuery : IRequest<
    PublisherDetailReadModel?>
{
    public required int PublisherId { get; init; }
}
