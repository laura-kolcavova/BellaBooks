namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class RemoveLibraryBranchContracts
{
    public record RequestDto
    {
        public required string LibraryBranchCode { get; init; }
    }
}
