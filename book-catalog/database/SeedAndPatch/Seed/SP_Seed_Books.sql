CREATE PROCEDURE [seed].[SP_Seed_Books]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Books] ON

    MERGE INTO [dbo].[Books] AS Target
    USING (VALUES
        (1, N'To Kill a Mockingbird', '9780446310789', 1, 1960, N'New York', N'English', 281, N'Some summary'),
        (2, N'1984', '9780451524935', 2, 1949, N'London', N'English', 328, N'Some summary'),
        (3, N'One Hundred Years of Solitude', '9780060883287', 3, 1967, N'Buenos Aires', N'Spanish', 417, N'Some summary'),
        (4, N'Brave New World', '9780060850524', 2, 1932, N'London', N'English', 311, N'Some summary'),
        (5, N'The Catcher in the Rye', '9780316769174', 4, 1951, N'Boston', N'English', 277, N'Some summary'),
        (6, N'Animal Farm', '9780452284241', 2, 1945, N'London', N'English', 112, N'Some summary'),
        (7, N'The Great Gatsby', '9780743273565', 5, 1925, N'New York', N'English', 180, N'Some summary'),
        (8, N'Beloved', '9781400033416', 6, 1987, N'New York', N'English', 324, N'Some summary'),
        (9, N'The Color Purple', '9780156031820', 7, 1982, N'New York', N'English', 295, N'Some summary'),
        (10, N'Slaughterhouse-Five', '9780440180296', 8, 1969, N'New York', N'English', 215, N'Some summary'),
        (11, N'A Brief History of Time', '9780553380163', 9, 1988, N'New York', N'English', 212, N'Some summary'),
        (12, N'Pride and Prejudice', '9780486284736', 10, 1813, N'London', N'English', 279, N'Some summary'),
        (13, N'The Hitchhiker''s Guide to the Galaxy', '9780345391803', 11, 1979, N'London', N'English', 193, N'Some summary'),
        (14, N'The Hobbit', '9780345339683', 12, 1937, N'London', N'English', 310, N'Some summary'),
        (15, N'The Lord of the Rings', '9780618640157', 12, 1954, N'London', N'English', 1178, N'Some summary'),
        (16, N'The Diary of a Young Girl', '9780553296983', 13, 1947, N'Amsterdam', N'Dutch', 283, N'Some summary'),
        (17, N'The Kite Runner', '9781594480003', 14, 2003, N'New York', N'English', 372, N'Some summary'),
        (18, N'The Alchemist', '9780062315007', 15, 1988, N'Rio de Janeiro', N'Portuguese', 197, N'Some summary'),
        (19, N'The Hunger Games', '9780439023481', 16, 2008, N'New York', N'English', 374, N'Some summary'),
        (20, N'Harry Potter and the Philosopher''s Stone', '9780747532743', 17, 1997, N'London', N'English', 223, N'Some summary')
    ) AS SOURCE (
        [Id],
        [Title],
        [Isbn],
        [PublisherId],
        [PublicationYear],
        [PublicationCity],
        [PublicationLanguage],
        [PageCount],
        [Summary]
    )
        ON (Target.[Id] = Source.[Id])
        WHEN MATCHED THEN
            UPDATE SET
                [Title] = Source.[Title],
                [Isbn] = Source.[Isbn],
                [PublisherId] = Source.[PublisherId],
                [PublicationYear] = Source.[PublicationYear],
                [PublicationCity] = Source.[PublicationCity],
                [PublicationLanguage] = Source.[PublicationLanguage],
                [PageCount] = Source.[PageCount],
                [Summary] = Source.[Summary]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [Id],
                [Title],
                [Isbn],
                [PublisherId],
                [PublicationYear],
                [PublicationCity],
                [PublicationLanguage],
                [PageCount],
                [Summary]
            )
            VALUES (
                Source.[Id],
                Source.[Title],
                Source.[Isbn],
                Source.[PublisherId],
                Source.[PublicationYear],
                Source.[PublicationCity],
                Source.[PublicationLanguage],
                Source.[PageCount],
                Source.[Summary]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END