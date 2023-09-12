using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

public class LibraryPrintEntityTypeConfiguration :
    IEntityTypeConfiguration<LibraryPrintEntity>
{
    public void Configure(EntityTypeBuilder<LibraryPrintEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.LibraryPrints), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .UseIdentityColumn();

        builder
            .Property(e => e.BookId)
            .IsRequired();

        builder
            .Property(e => e.Shelfmark)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(e => e.LibraryBranchCode)
            .HasMaxLength(2)
            .IsRequired();

        builder
            .Property(e => e.StateCode)
            .HasMaxLength(2)
            .HasStringEnumConversion()
            .IsRequired();

        builder
            .HasTrackableProperties();

        builder
            .HasOne(e => e.Book)
            .WithMany(f => f.LibraryPrints)
            .HasForeignKey(e => e.BookId);
    }
}
