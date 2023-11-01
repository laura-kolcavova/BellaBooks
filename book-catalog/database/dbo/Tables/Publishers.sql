﻿CREATE TABLE [dbo].[Publishers]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	[DateCreatedAt] DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET(),
	[DateUpdatedAt] DATETIMEOFFSET,

	CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED ([Id] ASC)
)
