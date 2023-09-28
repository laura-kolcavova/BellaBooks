﻿using BellaBooks.BookCatalog.Domain.Authors;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Authors.Commands;

public record GetAllAuthorsCommand : ICommand<
    ICollection<AuthorEntity>>
{
}