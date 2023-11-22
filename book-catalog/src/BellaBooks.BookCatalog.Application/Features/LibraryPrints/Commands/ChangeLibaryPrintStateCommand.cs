using BellaBooks.BookCatalog.Application.Errors;
using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;

public record ChangeLibaryPrintStateCommand : ICommand
    <UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }

    public required LibraryPrintStateCode StateCode { get; init; }
}
