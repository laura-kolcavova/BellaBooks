CREATE TABLE [dbo].[Books]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[Title] NVARCHAR(255) NOT NULL,
	[ISBN] CHAR(13) NOT NULL,
	[PublisherId] INT NOT NULL,
	[PublicationYear] SMALLINT NOT NULL,
	[PublicationPlace] VARCHAR(255),
	[PublicationLanguage] VARCHAR(255),
	[Pages] INT,
	[DateCreatedAt] DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET() NOT NULL,
	[DateUpdatedAt] DATETIMEOFFSET,
	CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Books_Publishers] FOREIGN KEY ([PublisherId]) REFERENCES [dbo].[Publishers] ([Id])
)
