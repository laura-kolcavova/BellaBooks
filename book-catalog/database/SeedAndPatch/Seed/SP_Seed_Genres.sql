CREATE PROCEDURE [seed].[SP_Seed_Genres]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Genres] ON

    MERGE INTO [dbo].[Genres] AS Target
    USING (VALUES
        (1, 'Fiction'),
        (2, 'Classic'),
        (3, 'Dystopian'),
        (4, 'Magic Realism'),
        (5, 'Jazz Age'),
        (6, 'Historical Fiction'),
        (7, 'Science Fiction'),
        (8, 'Non-fiction'),
        (9, 'Political Satire'),
        (10, 'Fantasy'),
        (11, 'Autobiography'),
        (12, 'Philosophical Fiction'),
        (13, 'Young Adult Fiction')
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