namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public static class AddLibraryPrintContracts
{
    public record Request
    {
        public required int BookId { get; init; }

        public required string LibraryBranchCode { get; init; }

        public required string Shelfmark { get; init; }
    }

    public record Response
    {
        public required int LibraryPrintId { get; init; }
    }
}
