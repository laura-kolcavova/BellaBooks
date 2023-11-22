namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class DisableLibraryBranchContracts
{
    public record RequestDto
    {
        public required string LibraryBranchCode { get; init; }
    }
}
