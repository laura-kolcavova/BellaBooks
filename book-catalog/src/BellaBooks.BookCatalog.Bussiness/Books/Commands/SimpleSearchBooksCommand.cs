﻿using BellaBooks.BookCatalog.Bussiness.Books;
using BellaBooks.BookCatalog.Domain.Books.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Books.Commands;

public class SimpleSearchBooksCommand : ICommand<
    ICollection<BookListingItemReadModel>>
{
    public required string SearchInput { get; init; }

    public required SimpleSearchFilter Filter { get; init; }
}