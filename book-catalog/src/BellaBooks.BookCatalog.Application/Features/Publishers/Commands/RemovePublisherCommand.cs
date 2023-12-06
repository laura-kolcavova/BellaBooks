﻿using BellaBooks.BookCatalog.Application.Errors;
using CSharpFunctionalExtensions;
using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Publishers.Commands;

public record RemovePublisherCommand : IRequest<
    UnitResult<ErrorResult>>
{
    public required int PublisherId { get; init; }
}
