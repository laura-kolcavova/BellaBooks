CREATE TABLE [dbo].[BooksGenres]
(
	[BookId] INT NOT NULL,
	[GenreId] INT NOT NULL,
	CONSTRAINT [PK_BooksGenres] PRIMARY KEY CLUSTERED ([BookId] ASC, [GenreId] ASC),
	CONSTRAINT [FK_BooksGenres_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
	CONSTRAINT [FK_BooksGenres_Genres] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id])
)
