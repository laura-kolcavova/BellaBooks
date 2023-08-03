using BellaBooks.BookCatalog.Domain;
using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BellaBooks.BookCatalog.Infrastructure.Contexts;

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

    public virtual DbSet<AuthorBookEntity> AuthorBooks => Set<AuthorBookEntity>();

    public virtual DbSet<BookGenreEntity> BookGenres => Set<BookGenreEntity>();

    public virtual DbSet<LibraryPrintEntity> LibraryPrints => Set<LibraryPrintEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new AuthorBookEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BookGenreEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new LibraryPrintEntityTypeConfiguration());
    }
}
