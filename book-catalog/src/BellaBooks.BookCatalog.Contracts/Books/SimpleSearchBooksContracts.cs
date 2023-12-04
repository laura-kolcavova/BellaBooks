using BellaBooks.BookCatalog.Application.Features.Books;

namespace BellaBooks.BookCatalog.Api.Contracts.Books;

public static class SimpleSearchBooksContracts
{
    public record RequestDto
    {
        public required string? SearchInput { get; init; }

        public required SimpleSearchFilter Filter { get; init; }

        //[FromQueryParams]
        //public required OffsetPaginationQueryDto OffsetPaginationQuery { get; init; }
    }

    public record ResponseDto
    {
        public required IReadOnlyCollection<BookListingItemDto> Books { get; init; }
    }
}
