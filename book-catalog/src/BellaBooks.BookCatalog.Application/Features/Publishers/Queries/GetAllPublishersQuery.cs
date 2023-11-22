using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Queries;

public record GetAllPublishersQuery : ICommand<
    ICollection<PublisherDetailReadModel>>
{
}
