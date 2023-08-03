using BellaBooks.BookCatalog.Domain.Genres;
using FastEndpoints;

namespace BellaBooks.BookCatalog.Bussiness.Genres.Commands;

public class GetAllGenresCommand : ICommand<
    ICollection<GenreEntity>>
{
}
