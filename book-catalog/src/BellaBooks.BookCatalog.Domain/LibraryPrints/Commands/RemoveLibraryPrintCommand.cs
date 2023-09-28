using BellaBooks.BookCatalog.Domain.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.LibraryPrints.Commands;

public record RemoveLibraryPrintCommand : ICommand<
      UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }
}
