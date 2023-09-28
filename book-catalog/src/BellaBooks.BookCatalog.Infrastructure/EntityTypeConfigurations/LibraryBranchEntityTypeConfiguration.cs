using BellaBooks.BookCatalog.Domain.LibraryBranches;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

internal class LibraryBranchEntityTypeConfiguration :
      IEntityTypeConfiguration<LibraryBranchEntity>
{
    public void Configure(EntityTypeBuilder<LibraryBranchEntity> builder)
    {
        builder
           .ToTable(nameof(BookCatalogContext.LibraryBranches), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => e.Code);

        builder
            .Property(e => e.Code)
            .HasMaxLength(2);

        builder
            .Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder
            .Property(e => e.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasTrackableProperties();
    }
}
