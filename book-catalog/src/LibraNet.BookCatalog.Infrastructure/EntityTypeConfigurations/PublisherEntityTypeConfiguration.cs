using LibraNet.BookCatalog.Domain.Entities.Publishers;
using LibraNet.BookCatalog.Infrastructure.Contexts;
using LibraNet.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraNet.BookCatalog.Infrastructure.EntityTypeConfigurations
{
    public class PublisherEntityTypeConfiguration
        : IEntityTypeConfiguration<PublisherEntity>
    {
        public void Configure(EntityTypeBuilder<PublisherEntity> builder)
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
