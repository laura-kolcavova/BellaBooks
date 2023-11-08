using BellaBooks.BookCatalog.Domain.Genres.ReadModels;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Commands;

public record GetAllGenresCommand : ICommand<
    ICollection<GenreDetailReadModel>>
{
}
