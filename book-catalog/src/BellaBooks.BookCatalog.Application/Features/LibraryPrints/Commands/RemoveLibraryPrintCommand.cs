using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.LibraryPrints.Commands;

public record RemoveLibraryPrintCommand : IRequest<
      UnitResult<ErrorResult>>
{
    public required int LibraryPrintId { get; init; }
}
