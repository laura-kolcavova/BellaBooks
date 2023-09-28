using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Domain.Genres.Commands;

public record GetAllGenresCommand : ICommand<
    ICollection<GenreEntity>>
{
}
