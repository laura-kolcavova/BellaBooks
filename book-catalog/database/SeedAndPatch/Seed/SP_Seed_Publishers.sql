CREATE PROCEDURE [seed].[SP_Seed_Publishers]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Publishers] ON

    MERGE INTO [dbo].[Publishers] AS Target
    USING (VALUES
        (1, N'HarperCollins'),
        (2, N'Penguin Books'),
        (3, N'Editorial Sudamericana'),
        (4, N'Little, Brown and Company'),
        (5, N'Charles Scribner''s Sons'),
        (6, N'Alfred A. Knopf'),
        (7, N'Harcourt Brace Jovanovich'),
        (8, N'Delacorte Press'),
        (9, N'Bantam Books'),
        (10, N'Thomas Egerton'),
        (11, N'Pan Books'),
        (12, N'George Allen & Unwin'),
        (13, N'Contact Publishing'),
        (14, N'Riverhead Books'),
        (15, N'Editora Rocco'),
        (16, N'Scholastic Corporation'),
        (17, N'Bloomsbury Publishing')
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