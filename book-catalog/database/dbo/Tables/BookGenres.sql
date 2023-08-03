CREATE TABLE [dbo].[BookGenres]
(
	[BookId] INT NOT NULL,
	[GenreId] INT NOT NULL,
	CONSTRAINT [PK_BookGenres] PRIMARY KEY CLUSTERED ([BookId] ASC, [GenreId] ASC),
	CONSTRAINT [FK_BookGenres_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
	CONSTRAINT [FK_BookGenres_Genres] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id])
)
