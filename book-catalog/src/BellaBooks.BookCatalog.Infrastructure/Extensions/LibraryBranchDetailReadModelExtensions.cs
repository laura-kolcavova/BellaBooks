using BellaBooks.BookCatalog.Domain.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryBranches.ReadModels;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class LibraryBranchDetailReadModelExtensions
{
    public static LibraryBranchDetailReadModel FromEntity(LibraryBranchEntity entity)
    {
        return new LibraryBranchDetailReadModel
        {
            Code = entity.Code,
            Name = entity.Name,
            IsActive = entity.IsActive,
        };
    }
}
