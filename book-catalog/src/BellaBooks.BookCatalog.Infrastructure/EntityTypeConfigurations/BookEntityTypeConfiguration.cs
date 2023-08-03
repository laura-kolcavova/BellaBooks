using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

public class BookEntityTypeConfiguration :
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
            .IsRequired();

        builder
            .Property(e => e.Summary);

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
                .HasMaxLength(255);

            navigationBuilder
                .Property(p => p.Language)
                .HasColumnName("PublicationLanguage")
                .HasMaxLength(255);
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
            .HasOne(e => e.Publisher)
            .WithMany(f => f.Books)
            .HasForeignKey(e => e.PublisherId);
    }
}
