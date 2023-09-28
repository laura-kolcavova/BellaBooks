namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public static class RemoveLibraryPrintContracts
{
    public record Request
    {
        public required int LibraryPrintId { get; init; }
    }
}
