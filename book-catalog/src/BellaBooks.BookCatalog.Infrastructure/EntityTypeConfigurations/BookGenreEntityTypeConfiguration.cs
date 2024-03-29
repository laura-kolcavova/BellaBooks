﻿using BellaBooks.BookCatalog.Domain.Entities;
using BellaBooks.BookCatalog.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;

internal class BookGenreEntityTypeConfiguration
    : IEntityTypeConfiguration<BookGenreEntity>
{
    public void Configure(EntityTypeBuilder<BookGenreEntity> builder)
    {
        builder
            .ToTable(nameof(BookCatalogContext.BookGenres), BookCatalogContext.DefaultSchema);

        builder
            .HasKey(e => new { e.BookId, e.GenreId });

        builder
            .Property(e => e.BookId)
            .IsRequired();

        builder
            .Property(e => e.GenreId)
            .IsRequired();

        builder
            .HasOne(e => e.Book)
            .WithMany(f => f.BookGenres)
            .HasForeignKey(e => e.BookId);
    }
}
