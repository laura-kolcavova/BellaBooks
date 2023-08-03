CREATE TABLE [dbo].[AuthorBooks]
(
	[AuthorId] INT NOT NULL,
	[BookId] INT NOT NULL,
	CONSTRAINT [PK_AuthorBooks] PRIMARY KEY CLUSTERED ([AuthorId] ASC, [BookId] ASC),
	CONSTRAINT [FK_AuthorBooks_Authors] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]),
	CONSTRAINT [FK_AuthorBooks_Books] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id])
)
