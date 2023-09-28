CREATE TABLE [dbo].[BookAuthors]
(
	[AuthorId] INT NOT NULL,
	[BookId] INT NOT NULL,

	CONSTRAINT [PK_BookAuthors] PRIMARY KEY CLUSTERED ([AuthorId] ASC, [BookId] ASC),

	CONSTRAINT [FK_BookAuthors_Authors] FOREIGN KEY ([AuthorId])
		REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE,

	CONSTRAINT [FK_BookAuthors_Books] FOREIGN KEY ([BookId])
		REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
)
