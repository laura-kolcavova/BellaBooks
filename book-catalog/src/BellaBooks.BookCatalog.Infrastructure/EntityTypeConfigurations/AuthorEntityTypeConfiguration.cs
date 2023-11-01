using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using BellaBooks.BookCatalog.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

internal class AuthorEntityTypeConfiguration :
    IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.Authors), BookCatalogContext.DefaultSchema);

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
