using BellaBooks.BookCatalog.Domain.Books.Commands;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class SimpleSearchBooksContracts
{
    public class Request
    {
        public required string? SearchInput { get; init; }

        public required SimpleSearchFilter Filter { get; init; }
    }

    public class Response
    {
        public required IReadOnlyCollection<BookListingItemDto> Books { get; init; }
    }
}
