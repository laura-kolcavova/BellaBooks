using BellaBooks.BookCatalog.Domain.LibraryPrints;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.LibraryPrints.Commands;

public record GetLibraryPrintsOfBook : ICommand<ICollection<LibraryPrintEntity>>
{
    public required int BookId { get; init; }
}
