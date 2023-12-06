using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;

public record MoveLibraryPrintToPositionCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }

    public required string Shelfmark { get; init; }

    public required string LibraryBranchCode { get; init; }
}
