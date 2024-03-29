﻿CREATE TABLE [dbo].[Books]
(
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR(255) NOT NULL,
    [PublisherId] INT NOT NULL,
    [Isbn] CHAR(13) NOT NULL,
    [PublicationYear] SMALLINT NOT NULL,
    [PublicationCity] NVARCHAR(200) NOT NULL,
    [PublicationLanguage] NVARCHAR(200) NOT NULL,
    [PageCount] SMALLINT,
    [Summary] NVARCHAR(500),
    [DateCreatedAt] DATETIMEOFFSET DEFAULT SYSDATETIMEOFFSET(),
    [DateUpdatedAt] DATETIMEOFFSET,

    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [AK_Books_Isbn] UNIQUE ([Isbn]),

    CONSTRAINT [FK_Books_Publishers] FOREIGN KEY ([PublisherId])
        REFERENCES [dbo].[Publishers] ([Id]) ON DELETE CASCADE
)

GO

CREATE NONCLUSTERED INDEX [IX_Books_Isbn]
    ON [dbo].[Books] ([Isbn])
    WITH (ONLINE=ON,SORT_IN_TEMPDB=ON,FILLFACTOR=80)

GO

CREATE NONCLUSTERED INDEX [IX_Books_Title]
    ON [dbo].[Books] ([Title])
    WITH (ONLINE=ON,SORT_IN_TEMPDB=ON,FILLFACTOR=80)
