using BellaBooks.BookCatalog.Domain.Entities.Genres;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

internal class GenreEntityTypeConfiguration :
    IEntityTypeConfiguration<GenreEntity>
{
    public void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.Genres), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .UseIdentityColumn();

        builder
            .Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasTrackableProperties();
    }
}
