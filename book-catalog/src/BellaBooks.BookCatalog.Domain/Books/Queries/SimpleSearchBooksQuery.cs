using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Books.Queries;

public record SimpleSearchBooksQuery : ICommand<
    ICollection<BookListingItemReadModel>>
{
    public required string? SearchInput { get; init; }

    public required SimpleSearchFilter Filter { get; init; }
}
