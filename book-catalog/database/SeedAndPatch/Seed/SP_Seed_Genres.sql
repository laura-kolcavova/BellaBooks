CREATE PROCEDURE [seed].[SP_Seed_Genres]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Genres] ON

    MERGE INTO [dbo].[Genres] AS Target
    USING (VALUES
        (1, N'Fiction'),
        (2, N'Classic'),
        (3, N'Dystopian'),
        (4, N'Magic Realism'),
        (5, N'Jazz Age'),
        (6, N'Historical Fiction'),
        (7, N'Science Fiction'),
        (8, N'Non-fiction'),
        (9, N'Political Satire'),
        (10, N'Fantasy'),
        (11, N'Autobiography'),
        (12, N'Philosophical Fiction'),
        (13, N'Young Adult Fiction')
    ) AS SOURCE (
        [Id],
        [Name]
    )
        ON (Target.[Id] = Source.[Id])
        WHEN MATCHED THEN
            UPDATE SET
                [Name] = Source.[Name]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [Id],
                [Name]
            )
            VALUES (
                Source.[Id],
                Source.[Name]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END