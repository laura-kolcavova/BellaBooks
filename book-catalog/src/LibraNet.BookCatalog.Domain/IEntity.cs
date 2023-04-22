namespace LibraNet.BookCatalog.Domain
{
    public interface IEntity
    {
    }

    public interface IEntity<out T>
    {
        T Id { get; }
    }
}
