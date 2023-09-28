namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class GetLibraryBranchDetailContracts
{
    public record Request
    {
        public required string LibraryBranchCode { get; init; }
    }

    public record Response
    {
        public required LibraryBranchDetailDto? LibraryBranch { get; init; }
    }
}
