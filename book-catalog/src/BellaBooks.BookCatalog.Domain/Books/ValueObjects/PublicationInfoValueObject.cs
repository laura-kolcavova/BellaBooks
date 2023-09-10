namespace BellaBooks.BookCatalog.Domain.Books.ValueObjects;

public record PublicationInfoValueObject
{
    public required string Isbn { get; init; }

    public required short Year { get; init; }

    public required string Language { get; init; }

    public required string City { get; init; }
}
