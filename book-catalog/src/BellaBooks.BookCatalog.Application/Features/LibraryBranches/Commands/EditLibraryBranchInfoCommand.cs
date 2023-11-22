using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.LibraryBranches.Commands;

public record EditLibraryBranchInfoCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required string LibraryBranchCode { get; init; }

    public required string Name { get; init; }
}
