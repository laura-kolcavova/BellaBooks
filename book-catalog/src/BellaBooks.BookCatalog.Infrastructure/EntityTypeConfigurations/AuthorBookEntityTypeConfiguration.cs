using BellaBooks.BookCatalog.Domain;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

public class AuthorBookEntityTypeConfiguration :
    IEntityTypeConfiguration<AuthorBookEntity>
{
    public void Configure(EntityTypeBuilder<AuthorBookEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.AuthorBooks), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => new { e.AuthorId, e.BookId });

        builder
            .Property(e => e.AuthorId)
            .IsRequired();

        builder
            .Property(e => e.BookId)
            .IsRequired();

        builder
            .HasOne(e => e.Author)
            .WithMany(f => f.AuthorBooks)
            .HasForeignKey(e => e.AuthorId);

        builder
            .HasOne(e => e.Book)
            .WithMany(f => f.AuthorBooks)
            .HasForeignKey(e => e.BookId);
    }
}
