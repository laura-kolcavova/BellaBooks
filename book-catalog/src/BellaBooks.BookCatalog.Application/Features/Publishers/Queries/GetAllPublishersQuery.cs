using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Queries;

public record GetAllPublishersQuery : IRequest<
    IReadOnlyCollection<PublisherDetailReadModel>>
{
}
