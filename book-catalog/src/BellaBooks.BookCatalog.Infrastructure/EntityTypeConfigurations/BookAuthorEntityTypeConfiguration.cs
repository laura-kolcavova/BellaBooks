using BellaBooks.BookCatalog.Domain;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

internal class BookAuthorEntityTypeConfiguration :
    IEntityTypeConfiguration<BookAuthorEntity>
{
    public void Configure(EntityTypeBuilder<BookAuthorEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.BookAuthors), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => new { e.AuthorId, e.BookId });

        builder
            .Property(e => e.AuthorId)
            .IsRequired();

        builder
            .Property(e => e.BookId)
            .IsRequired();

        builder
            .HasOne(e => e.Book)
            .WithMany(f => f.BookAuthors)
            .HasForeignKey(e => e.BookId);
    }
}
