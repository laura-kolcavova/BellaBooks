﻿using BellaBooks.BookCatalog.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BellaBooks.BookCatalog.Infrastructure.Extensions;

internal static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> HasTrackableProperties<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, ITrackableEntity
    {
        builder
            .Property(o => o.CreatedAt)
            .HasColumnName("DateCreatedAt");

        builder
            .Property(c => c.UpdatedAt)
            .HasColumnName("DateUpdatedAt");

        return builder;
    }
}
