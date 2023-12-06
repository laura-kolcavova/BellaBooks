using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Queries;

public record GetAuthorDetailQuery : IRequest<
     AuthorDetailReadModel?>
{
    public required int AuthorId { get; init; }
}
