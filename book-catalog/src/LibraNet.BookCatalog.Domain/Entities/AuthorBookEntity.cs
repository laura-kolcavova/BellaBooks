using LibraNet.BookCatalog.Domain.Entities.Authors;
using LibraNet.BookCatalog.Domain.Entities.Books;

namespace LibraNet.BookCatalog.Domain.Entities
{
    public class AuthorBookEntity : IEntity
    {
        public int AuthorId { get; }

        public int BookId { get; }

        #region NavigationProperties

        public AuthorEntity Author { get; } = null!;

        public BookEntity Book { get; } = null!;

        #endregion NavigationProperties

        public AuthorBookEntity(int authorId, int bookId)
        {
            AuthorId = authorId;
            BookId = bookId;
        }
    }
}
