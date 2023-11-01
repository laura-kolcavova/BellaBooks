using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryBranches.Commands;

public record AddLibraryBranchCommand : ICommand<
    Result<string, ErrorResult>>
{
    public required string LibraryBranchCode { get; init; }

    public required string Name { get; init; }
}
