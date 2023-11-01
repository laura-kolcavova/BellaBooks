﻿namespace BellaBooks.BookCatalog.Api.Contracts.LibraryBranches;

public static class ActivateLibraryBranchContracts
{
    public record RequestDto
    {
        public required string LibraryBranchCode { get; init; }
    }
}
