namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public static class RemoveLibraryPrintContracts
{
    public record RequestDto
    {
        public required int LibraryPrintId { get; init; }
    }
}
