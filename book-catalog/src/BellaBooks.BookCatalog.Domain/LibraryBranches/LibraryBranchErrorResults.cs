using BellaBooks.BookCatalog.Domain.Constants;
using BellaBooks.BookCatalog.Domain.Errors;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches;

public static class LibraryBranchErrorResults
{
    public static ErrorResult LibraryBranchNotFound => new(
        ErrorCodes.LibraryBranches.LibraryBranchNotFound,
        "A library branch was not found.");

    public static ErrorResult LibraryBranchWithSameCodeAlreadyExists => new(
        ErrorCodes.LibraryBranches.LibraryBranchWithSameCodeAlreadyExists,
        "A library branch with same code already exists.");

    public static ErrorResult LibraryBranchNotAdded => new(
        ErrorCodes.LibraryBranches.LibraryBranchNotAdded,
        "A library branch was not added.");

    public static ErrorResult LibraryBranchInfoNotUpdated => new(
        ErrorCodes.LibraryBranches.LibraryBranchInfoNotUpdated,
        "An information about library branch was not updated.");

    public static ErrorResult LibraryBranchNotRemoved => new(
        ErrorCodes.LibraryBranches.LibraryBranchNotRemoved,
        "A library branch was not removed.");

    public static ErrorResult LibraryBranchIsDisabled => new(
       ErrorCodes.LibraryBranches.LibraryBranchIsDisabled,
       "A library branch is disabled.");

    public static ErrorResult LibraryBranchActivatingFailed => new(
     ErrorCodes.LibraryBranches.LibraryBranchActivatingFailed,
     "A library branch was not activated.");

    public static ErrorResult LibraryBranchDisablingFailed => new(
     ErrorCodes.LibraryBranches.LibraryBranchDisablingFailed,
     "A library branch was not disabled.");
}
