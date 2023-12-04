using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;

public record RemoveLibraryPrintCommand : ICommand<
      UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }
}
