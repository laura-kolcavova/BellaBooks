﻿using BellaBooks.BookCatalog.Api.Contracts.Books;
using BellaBooks.BookCatalog.Domain.Books;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Ednpoints.Books.GetBookDetail;

public class GetBookDetailResponseMapper : ResponseMapper<
    GetBookDetailDto.Response,
    BookEntity>
{
    public override GetBookDetailDto.Response FromEntity(BookEntity e)
    {
        return new()
        {
            BookDetail = BookDetailDto.FromEntity(e),
        };
    }
}