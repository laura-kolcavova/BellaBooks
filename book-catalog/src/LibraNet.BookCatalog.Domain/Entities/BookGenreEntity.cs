using LibraNet.BookCatalog.Domain.Entities.Books;
using LibraNet.BookCatalog.Domain.Entities.Genres;

namespace LibraNet.BookCatalog.Domain.Entities
{
    public class BookGenreEntity : IEntity
    {
        public int BookId { get; }

        public int GenreId { get; }

        #region NavigationProperties

        public BookEntity Book { get; } = null!;

        public GenreEntity Genre { get; } = null!;

        #endregion NavigationProperties

        public BookGenreEntity(int bookId, int genreId)
        {
            BookId = bookId;
            GenreId = genreId;
        }
    }
}
