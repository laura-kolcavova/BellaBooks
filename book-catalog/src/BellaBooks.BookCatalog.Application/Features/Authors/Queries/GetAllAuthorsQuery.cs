using MediatR;

namespace BellaBooks.BookCatalog.Application.Features.Authors.Queries;

public record GetAllAuthorsQuery : IRequest<
    IReadOnlyCollection<AuthorDetailReadModel>>
{
}
