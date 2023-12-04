namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public static class AddLibraryPrintContracts
{
    public record RequestDto
    {
        public required int BookId { get; init; }

        public required string LibraryBranchCode { get; init; }

        public required string Shelfmark { get; init; }
    }

    public record ResponseDto
    {
        public required int LibraryPrintId { get; init; }
    }
}
