using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;

public record DisableLibraryBranchCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required string LibraryBranchCode { get; init; }
}
