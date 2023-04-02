CREATE TABLE [dbo].[BooksAuthors]
(
	[BookId] INT NOT NULL,
	[AuthorId] INT NOT NULL,
	CONSTRAINT [PK_BooksAuthors] PRIMARY KEY CLUSTERED ([BookId] ASC, [AuthorId] ASC),
	CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
	CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id])
)
