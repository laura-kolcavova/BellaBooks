using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints.Commands;

public record ChangeLibaryPrintStateCommand : ICommand
    <UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }

    public required LibraryPrintStateCode StateCode { get; init; }
}
