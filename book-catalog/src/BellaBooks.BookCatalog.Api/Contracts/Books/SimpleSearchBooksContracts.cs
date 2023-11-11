using BellaBooks.BookCatalog.Domain.Books;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class SimpleSearchBooksContracts
{
    public class RequestDto
    {
        public required string? SearchInput { get; init; }

        public required SimpleSearchFilter Filter { get; init; }
    }

    public class ResponseDto
    {
        public required IReadOnlyCollection<BookListingItemDto> Books { get; init; }
    }
}
