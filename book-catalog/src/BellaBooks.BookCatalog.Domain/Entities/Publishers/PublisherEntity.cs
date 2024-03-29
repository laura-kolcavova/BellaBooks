﻿using BellaBooks.BookCatalog.Domain.Common;

namespace BellaBooks.BookCatalog.Domain.Entities.Publishers;

public class PublisherEntity : IEntity<int>, ITrackableEntity
{
    public int Id { get; }

    public string Name { get; }

    public DateTimeOffset? CreatedAt { get; }

    public DateTimeOffset? UpdatedAt { get; }

    public PublisherEntity(string name)
    {
        Name = name;
    }
}
