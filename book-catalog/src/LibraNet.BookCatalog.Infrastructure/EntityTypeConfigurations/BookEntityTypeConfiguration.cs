using LibraNet.BookCatalog.Domain.Entities.Books;
using LibraNet.BookCatalog.Infrastructure.Contexts;
using LibraNet.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNet.BookCatalog.Infrastructure.EntityTypeConfigurations
{
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
                .UseIdentityColumn(1, 1);

            builder
                .Property(e => e.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR");

            builder
                .Property(e => e.ISBN)
                .IsRequired()
                .HasColumnType("CHAR")
                .HasMaxLength(13);

            builder
                .Property(e => e.PublisherId)
                .IsRequired()
                .HasColumnType("INT");

            builder
                .Property(e => e.PublicationYear)
                .IsRequired()
                .HasColumnType("SMALLINT");

            builder
                .Property(e => e.PublicationPlace)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder
                .Property(e => e.PublicationLanguage)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder
                .Property(e => e.Pages)
                .HasColumnType("INT");

            builder
                .HasTrackableProperties();

            builder
                .HasOne(e => e.Publisher)
                .WithMany(f => f.Books)
                .HasForeignKey(e => e.PublisherId);
        }
    }
}
