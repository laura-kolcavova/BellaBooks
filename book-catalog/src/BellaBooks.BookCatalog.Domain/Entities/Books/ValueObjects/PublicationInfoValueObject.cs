using CSharpFunctionalExtensions;

namespace BellaBooks.BookCatalog.Domain.Entities.Books.ValueObjects;

public class PublicationInfoValueObject : ValueObject
{
    public string Isbn { get; }

    public short Year { get; }

    public string City { get; }

    public string Language { get; }

    public PublicationInfoValueObject(string isbn, short year, string city, string language)
    {
        Isbn = isbn;
        Year = year;
        City = city;
        Language = language;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Isbn;
        yield return Year;
        yield return City;
        yield return Language;
    }
}
