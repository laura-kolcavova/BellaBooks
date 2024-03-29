﻿using BellaBooks.BookCatalog.Domain.Common;

namespace BellaBooks.BookCatalog.Domain.Entities.Genres;

public class GenreEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    public GenreEntity(string name)
    {
        Name = name;
    }
}
