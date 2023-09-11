CREATE TABLE [dbo].[LibraryPrints]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, -- AccessionNumber
	[BookId] INT NOT NULL,
	[Shelfmark] VARCHAR(20) NOT NULL,
	[LibraryBrancheCode] CHAR(2) NOT NULL,
	[StateCode] CHAR(2) NOT NULL,
	[DateCreatedAt] DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET(),
	[DateUpdatedAt] DATETIMEOFFSET,
	CONSTRAINT [PK_LibraryPrints] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_LibraryPrints_Books] FOREIGN KEY ([BookId])
		REFERENCES [dbo].[Books] ([Id]) ON DELETE CASCADE
)
