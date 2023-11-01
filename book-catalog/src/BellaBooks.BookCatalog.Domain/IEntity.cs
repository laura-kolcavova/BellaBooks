namespace BellaBooks.BookCatalog.Domain;

public interface IEntity
{
}

public interface IEntity<out TPrimaryKey>
{
    TPrimaryKey Id { get; }
}
