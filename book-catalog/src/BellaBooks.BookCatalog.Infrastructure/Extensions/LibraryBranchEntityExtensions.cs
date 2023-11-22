using BellaBooks.BookCatalog.Application.Features.LibraryBranches.Queries;
using BellaBooks.BookCatalog.Domain.Entities.LibraryBranches;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

public static class LibraryBranchEntityExtensions
{
    public static IQueryable<LibraryBranchDetailReadModel> SelectLibraryBranchDetailReadModel(this IQueryable<LibraryBranchEntity> libraryBranches)
    {
        return libraryBranches
            .Select(libraryBranch => new LibraryBranchDetailReadModel
            {
                Code = libraryBranch.Code,
                Name = libraryBranch.Name,
                IsActive = libraryBranch.IsActive,
            });
    }
}
