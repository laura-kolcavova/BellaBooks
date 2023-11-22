using BellaBooks.BookCatalog.Domain.Entities;
using BellaBooks.BookCatalog.Domain.Entities.Authors;
using BellaBooks.BookCatalog.Domain.Entities.Books;
using BellaBooks.BookCatalog.Domain.Entities.Genres;
using BellaBooks.BookCatalog.Domain.Entities.LibraryBranches;
using BellaBooks.BookCatalog.Domain.Entities.LibraryPrints;
using BellaBooks.BookCatalog.Domain.Entities.Publishers;
using BellaBooks.BookCatalog.Infrastructure.Common;
using BellaBooks.BookCatalog.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
           .UseSqlServer(_connectionString);

        if (_useDevelopmentLogging)
        {
            optionsBuilder
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }
    }

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

    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder =>
            builder.AddConsole());
    }
}
