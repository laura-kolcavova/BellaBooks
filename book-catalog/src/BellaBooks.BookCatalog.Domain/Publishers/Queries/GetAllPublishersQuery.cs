using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Queries;

public record GetAllPublishersQuery : ICommand<
    IReadOnlyCollection<PublisherDetailReadModel>>
{
}
