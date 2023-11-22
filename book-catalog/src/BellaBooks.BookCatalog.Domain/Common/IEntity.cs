namespace BellaBooks.BookCatalog.Domain.Common;

public interface IEntity
{
}

public interface IEntity<out TPrimaryKey>
{
    TPrimaryKey Id { get; }
}
