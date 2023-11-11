using System.Text.Json.Serialization;

namespace BellaBooks.BookCatalog.Domain.Constants.LibraryPrints;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LibraryPrintStateCode
{
    // Available
    AV,

    // Reserved
    RS,

    // OnHold
    //OH,

    // OnLoan
    OL,

    // NotAvailable
    NA
}
