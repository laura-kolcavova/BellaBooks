using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public static class ChangeLibraryPrintStateContracts
{
    public record Request
    {
        public required int LibraryPrintId { get; init; }

        public required LibraryPrintStateCode StateCode { get; init; }
    }
}
