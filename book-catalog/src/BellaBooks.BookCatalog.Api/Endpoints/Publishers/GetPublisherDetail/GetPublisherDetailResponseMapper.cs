﻿using BellaBooks.BookCatalog.Api.Contracts.Publishers;
using BellaBooks.BookCatalog.Domain.Publishers;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Api.Endpoints.Publishers.GetPublisherDetail;

internal class GetPublisherDetailResponseMapper : ResponseMapper<
    GetPublisherDetailContracts.Response, PublisherEntity?>
{
    public override GetPublisherDetailContracts.Response FromEntity(PublisherEntity? e)
    {
        return new()
        {
            Publisher = e == null
                ? null
                : PublisherDetailDto.FromEntity(e),
        };
    }
}
