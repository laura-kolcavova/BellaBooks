using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints.Commands;

public record MoveLibraryPrintToPositionCommand : ICommand<
    UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }

    public required string Shelfmark { get; init; }

    public required string LibraryBranchCode { get; init; }
}
