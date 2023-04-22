using LibraNet.BookCatalog.Domain.Entities;
using LibraNet.BookCatalog.Domain.Entities.Authors;
using LibraNet.BookCatalog.Domain.Entities.Books;
using LibraNet.BookCatalog.Domain.Entities.Genres;
using LibraNet.BookCatalog.Domain.Entities.Publishers;
using LibraNet.BookCatalog.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LibraNet.BookCatalog.Infrastructure.Contexts
{
    public class BookCatalogContext : BaseDbContext<BookCatalogContext>
    {
        public const string DefaultSchema = "dbo";

        public BookCatalogContext(DbContextOptions<BookCatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorEntity> Authors => Set<AuthorEntity>();

        public virtual DbSet<PublisherEntity> Publishers => Set<PublisherEntity>();

        public virtual DbSet<GenreEntity> Genres => Set<GenreEntity>();

        public virtual DbSet<BookEntity> Books => Set<BookEntity>();

        public virtual DbSet<AuthorBookEntity> AuthorsBooks => Set<AuthorBookEntity>();

        public virtual DbSet<BookGenreEntity> BooksGenres => Set<BookGenreEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new  GenreEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorBookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreEntityTypeConfiguration());
        }

    }
}
