namespace BellaBooks.BookCatalog.Domain.LibraryBranches;

public class LibraryBranchEntity : IEntity, ITrackableEntity
{
    public string Code { get; }

    public string Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    public LibraryBranchEntity(string code, string name)
    {
        Code = code;
        Name = name;
        IsActive = true;
    }

    public LibraryBranchEntity Activate()
    {
        IsActive = true;
        return this;
    }

    public LibraryBranchEntity Disable()
    {
        IsActive = false;
        return this;
    }
}
