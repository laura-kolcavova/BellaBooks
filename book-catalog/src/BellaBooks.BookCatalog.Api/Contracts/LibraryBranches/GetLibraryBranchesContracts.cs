namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class GetLibraryBranchesContracts
{
    public record Response
    {
        public required IReadOnlyCollection<LibraryBranchDetailDto> LibraryBranches { get; set; }
    }
}
