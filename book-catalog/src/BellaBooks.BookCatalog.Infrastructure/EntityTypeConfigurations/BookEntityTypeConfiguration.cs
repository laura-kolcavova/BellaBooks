using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

internal class BookEntityTypeConfiguration :
    IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.Books), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .UseIdentityColumn();

        builder
            .Property(e => e.PublisherId)
            .IsRequired();

        builder
            .Property(e => e.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(e => e.Summary)
            .HasMaxLength(500);

        builder.OwnsOne(e => e.PublicationInfo, navigationBuilder =>
        {
            navigationBuilder
                .Property(e => e.Isbn)
                .HasColumnName("Isbn")
                .HasMaxLength(13)
                .IsRequired();

            navigationBuilder
                .Property(p => p.Year)
                .HasColumnName("PublicationYear");

            navigationBuilder
                .Property(p => p.City)
                .HasColumnName("PublicationCity")
                .HasMaxLength(200);

            navigationBuilder
                .Property(p => p.Language)
                .HasColumnName("PublicationLanguage")
                .HasMaxLength(200);
        });

        builder.OwnsOne(e => e.FormatInfo, navigationBuilder =>
        {
            navigationBuilder
                .Property(p => p.PageCount)
                .HasColumnName("PageCount");
        });

        builder
            .HasTrackableProperties();

        builder
            .HasMany(e => e.BookAuthors)
            .WithOne(f => f.Book)
            .HasForeignKey(e => e.BookId);

        builder
           .HasMany(e => e.BookGenres)
           .WithOne(f => f.Book)
           .HasForeignKey(e => e.BookId);
    }
}
