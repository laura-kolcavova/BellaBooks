using LibraNet.BookCatalog.Domain.Entities.Genres;
using LibraNet.BookCatalog.Infrastructure.Contexts;
using LibraNet.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNet.BookCatalog.Infrastructure.EntityTypeConfigurations
{
    public class GenreEntityTypeConfiguration :
        IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {
            builder
                .ToTable(nameof(BookCatalogContext.Publishers), BookCatalogContext.DefaultSchema);

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .UseIdentityColumn();

            builder
                .Property(e => e.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder
                .HasTrackableProperties();
        }
    }
}
