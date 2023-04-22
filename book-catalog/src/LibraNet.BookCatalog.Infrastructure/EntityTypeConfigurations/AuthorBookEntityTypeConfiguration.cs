using LibraNet.BookCatalog.Domain.Entities;
using LibraNet.BookCatalog.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNet.BookCatalog.Infrastructure.EntityTypeConfigurations
{
    public class AuthorBookEntityTypeConfiguration :
        IEntityTypeConfiguration<AuthorBookEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorBookEntity> builder)
        {
            builder
                .ToTable(nameof(BookCatalogContext.AuthorsBooks), BookCatalogContext.DefaultSchema);

            builder
                .HasKey(e => new { e.AuthorId, e.BookId });

            builder
                .Property(e => e.AuthorId)
                .IsRequired()
                .HasColumnType("INT");

            builder
                .Property(e => e.BookId)
                .IsRequired()
                .HasColumnType("INT");

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
}
