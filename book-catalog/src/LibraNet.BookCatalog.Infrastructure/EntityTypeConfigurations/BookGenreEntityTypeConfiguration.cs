using LibraNet.BookCatalog.Domain.Entities;
using LibraNet.BookCatalog.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNet.BookCatalog.Infrastructure.EntityTypeConfigurations
{
    public class BookGenreEntityTypeConfiguration
        : IEntityTypeConfiguration<BookGenreEntity>
    {
        public void Configure(EntityTypeBuilder<BookGenreEntity> builder)
        {
            builder
                .ToTable(nameof(BookCatalogContext.BooksGenres), BookCatalogContext.DefaultSchema);

            builder
                .HasKey(e => new { e.BookId, e.GenreId });

            builder
                .Property(e => e.BookId)
                .IsRequired()
                .HasColumnType("INT");

            builder
                .Property(e => e.GenreId)
                .IsRequired()
                .HasColumnType("INT");

            builder
                .HasOne(e => e.Book)
                .WithMany(f => f.BookGenres)
                .HasForeignKey(e => e.BookId);

            builder
                .HasOne(e => e.Genre)
                .WithMany(f => f.BookGenres)
                .HasForeignKey(e => e.GenreId);
        }
    }
}
