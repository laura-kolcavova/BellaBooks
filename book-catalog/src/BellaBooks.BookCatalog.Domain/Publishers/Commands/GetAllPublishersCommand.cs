using BellaBooks.BookCatalog.Domain.Publishers.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Commands;

public record GetAllPublishersCommand : ICommand<
    ICollection<PublisherDetailReadModel>>
{
}
