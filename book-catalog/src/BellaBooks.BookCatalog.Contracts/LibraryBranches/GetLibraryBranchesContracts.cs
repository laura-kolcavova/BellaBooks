namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class GetLibraryBranchesContracts
{
    public record ResponseDto
    {
        public required IReadOnlyCollection<LibraryBranchDetailDto> LibraryBranches { get; set; }
    }
}
