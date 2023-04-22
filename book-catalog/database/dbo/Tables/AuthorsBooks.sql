CREATE TABLE [dbo].[AuthorsBooks]
(
	[AuthorId] INT NOT NULL,
	[BookId] INT NOT NULL,
	CONSTRAINT [PK_AuthorsBooks] PRIMARY KEY CLUSTERED ([AuthorId] ASC, [BookId] ASC),
	CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]),
	CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id])
)
