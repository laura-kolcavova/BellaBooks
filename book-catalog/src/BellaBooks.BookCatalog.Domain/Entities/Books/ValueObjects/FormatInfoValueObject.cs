using CSharpFunctionalExtensions;

namespace BellaBooks.BookCatalog.Domain.Entities.Books.ValueObjects;

public class FormatInfoValueObject : ValueObject
{
    public short? PageCount { get; }

    public FormatInfoValueObject(short? pageCount)
    {
        PageCount = pageCount;
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        if (PageCount != null)
        {
            yield return PageCount;
        }
    }
}
