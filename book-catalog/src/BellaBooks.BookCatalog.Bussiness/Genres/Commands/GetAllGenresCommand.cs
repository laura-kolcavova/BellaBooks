using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public record GetAllGenresCommand : ICommand<
    ICollection<GenreEntity>>
{
}
