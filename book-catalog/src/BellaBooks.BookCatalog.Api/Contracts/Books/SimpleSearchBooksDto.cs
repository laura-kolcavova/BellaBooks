using BellaBooks.BookCatalog.Bussiness.Books;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class SimpleSearchBooksDto
{
    public class Request
    {
        public required string SearchInput { get; init; }

        public required SimpleSearchFilter Filter { get; init; }
    }

    public class Response
    {
        public required IReadOnlyCollection<BookListingItemDto> Books { get; init; }
    }
}
