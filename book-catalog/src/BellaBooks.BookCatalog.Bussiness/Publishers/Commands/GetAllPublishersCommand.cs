using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Publishers.Commands;

public record GetAllPublishersCommand : ICommand<
    ICollection<PublisherEntity>>
{
}
