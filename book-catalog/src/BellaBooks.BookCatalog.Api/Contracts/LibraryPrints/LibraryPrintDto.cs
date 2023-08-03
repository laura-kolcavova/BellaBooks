using BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using System.Text.Json.Serialization;

namespace BellaBooks.BookCatalog.Api.Contracts.LibraryPrints;

public class LibraryPrintDto
{
    public required int Id { get; init; }

    public required int BookId { get; init; }

    public required string Shelfmark { get; init; }

    public required string LibraryBrancheCode { get; init; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required LibraryPrintStateCode StateCode { get; init; }

    public static LibraryPrintDto FromEntity(LibraryPrintEntity entity)
    {
        return new LibraryPrintDto
        {
            Id = entity.Id,
            BookId = entity.BookId,
            Shelfmark = entity.Shelfmark,
            LibraryBrancheCode = entity.LibraryBrancheCode,
            StateCode = entity.StateCode,
        };
    }
}
