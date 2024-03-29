﻿using FastEndpoints;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Queries;

public record GetAllAuthorsQuery : ICommand<
    IReadOnlyCollection<AuthorDetailReadModel>>
{
}
