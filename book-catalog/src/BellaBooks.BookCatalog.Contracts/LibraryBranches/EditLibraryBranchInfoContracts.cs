namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class EditLibraryBranchInfoContracts
{
    public record RequestDto
    {
        public required string LibraryBranchCode { get; init; }

        public required string Name { get; init; }
    }
}
