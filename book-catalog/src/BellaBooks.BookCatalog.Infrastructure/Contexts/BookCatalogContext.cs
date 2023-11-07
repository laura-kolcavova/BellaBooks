using BellaBooks.BookCatalog.Domain;
using BellaBooks.BookCatalog.Domain.Authors;
using BellaBooks.BookCatalog.Domain.Books;
using BellaBooks.BookCatalog.Domain.Genres;
using BellaBooks.BookCatalog.Domain.LibraryBranches;
using BellaBooks.BookCatalog.Domain.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Publishers;
using BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BellaBooks.BookCatalog.Infrastructure.Contexts;

internal class BookCatalogContext : BaseDbContext<BookCatalogContext>
{
    public const string DefaultSchema = "dbo";

    private readonly string _connectionString;
    private readonly bool _useDevelopmentLogging;

    public BookCatalogContext(string connectionString, bool useDevelopmentLogging)
    {
        _connectionString = connectionString;
        _useDevelopmentLogging = useDevelopmentLogging;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
           .UseSqlServer(_connectionString)
           .EnableDetailedErrors(_useDevelopmentLogging)
           .EnableSensitiveDataLogging(_useDevelopmentLogging);
    }

    public virtual DbSet<LibraryBranchEntity> LibraryBranches =>
        Set<LibraryBranchEntity>();

    public virtual DbSet<AuthorEntity> Authors =>
        Set<AuthorEntity>();

    public virtual DbSet<PublisherEntity> Publishers =>
        Set<PublisherEntity>();

    public virtual DbSet<GenreEntity> Genres =>
        Set<GenreEntity>();

    public virtual DbSet<BookEntity> Books =>
        Set<BookEntity>();

    public virtual DbSet<BookAuthorEntity> BookAuthors =>
        Set<BookAuthorEntity>();

    public virtual DbSet<BookGenreEntity> BookGenres =>
        Set<BookGenreEntity>();

    public virtual DbSet<LibraryPrintEntity> LibraryPrints =>
        Set<LibraryPrintEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LibraryBranchEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PublisherEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new BookAuthorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BookGenreEntityTypeConfiguration());

        modelBuilder.ApplyConfiguration(new LibraryPrintEntityTypeConfiguration());
    }
}
