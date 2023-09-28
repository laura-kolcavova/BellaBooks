namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public static class MoveLibraryPrintToPositionContracts
{
    public record Request
    {
        public int LibraryPrintId { get; init; }

        public required string LibraryBranchCode { get; init; }

        public required string Shelfmark { get; init; }
    }
}
