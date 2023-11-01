using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Publishers.Commands;

public record GetAllPublishersCommand : ICommand<
    ICollection<PublisherEntity>>
{
}
