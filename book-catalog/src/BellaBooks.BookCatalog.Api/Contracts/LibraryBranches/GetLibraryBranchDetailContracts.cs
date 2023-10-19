namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class GetLibraryBranchDetailContracts
{
    public record RequestDto
    {
        public required string LibraryBranchCode { get; init; }
    }

    public record ResponseDto
    {
        public required LibraryBranchDetailDto? LibraryBranch { get; init; }
    }
}
