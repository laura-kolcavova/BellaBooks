namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class AddLibraryBranchContracts
{
    public record RequestDto
    {
        public required string LibraryBranchCode { get; init; }

        public required string Name { get; init; }
    }

    public record ResponseDto
    {
        public required string LibraryBranchCode { get; init; }
    }
}
