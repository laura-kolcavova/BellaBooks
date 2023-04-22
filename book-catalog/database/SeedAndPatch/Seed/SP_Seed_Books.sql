CREATE PROCEDURE [seed].[SP_Seed_Books]
AS
BEGIN
    SET IDENTITY_INSERT [dbo].[Books] ON

    MERGE INTO [dbo].[Books] AS Target
    USING (VALUES
        (1, 'To Kill a Mockingbird', '9780446310789', 1, 1960, 'New York', 'English', 281),
        (2, '1984', '9780451524935', 2, 1949, 'London', 'English', 328),
        (3, 'One Hundred Years of Solitude', '9780060883287', 3, 1967, 'Buenos Aires', 'Spanish', 417),
        (4, 'Brave New World', '9780060850524', 2, 1932, 'London', 'English', 311),
        (5, 'The Catcher in the Rye', '9780316769174', 4, 1951, 'Boston', 'English', 277),
        (6, 'Animal Farm', '9780452284241', 2, 1945, 'London', 'English', 112),
        (7, 'The Great Gatsby', '9780743273565', 5, 1925, 'New York', 'English', 180),
        (8, 'Beloved', '9781400033416', 6, 1987, 'New York', 'English', 324),
        (9, 'The Color Purple', '9780156031820', 7, 1982, 'New York', 'English', 295),
        (10, 'Slaughterhouse-Five', '9780440180296', 8, 1969, 'New York', 'English', 215),
        (11, 'A Brief History of Time', '9780553380163', 9, 1988, 'New York', 'English', 212),
        (12, 'Pride and Prejudice', '9780486284736', 10, 1813, 'London', 'English', 279),
        (13, 'The Hitchhiker''s Guide to the Galaxy', '9780345391803', 11, 1979, 'London', 'English', 193),
        (14, 'The Hobbit', '9780345339683', 12, 1937, 'London', 'English', 310),
        (15, 'The Lord of the Rings', '9780618640157', 12, 1954, 'London', 'English', 1178),
        (16, 'The Diary of a Young Girl', '9780553296983', 13, 1947, 'Amsterdam', 'Dutch', 283),
        (17, 'The Kite Runner', '9781594480003', 14, 2003, 'New York', 'English', 372),
        (18, 'The Alchemist', '9780062315007', 15, 1988, 'Rio de Janeiro', 'Portuguese', 197),
        (19, 'The Hunger Games', '9780439023481', 16, 2008, 'New York', 'English', 374),
        (20, 'Harry Potter and the Philosopher''s Stone', '9780747532743', 17, 1997, 'London', 'English', 223)
    ) AS SOURCE (
        [Id],
        [Title],
        [ISBN],
        [PublisherId],
        [PublicationYear],
        [PublicationPlace],
        [PublicationLanguage],
        [Pages]
    )
        ON (Target.[Id] = Source.[Id])
        WHEN MATCHED THEN
            UPDATE SET
                [Title] = Source.[Title],
                [ISBN] = Source.[ISBN],
                [PublisherId] = Source.[PublisherId],
                [PublicationYear] = Source.[PublicationYear],
                [PublicationPlace] = Source.[PublicationPlace],
                [PublicationLanguage] = Source.[PublicationLanguage],
                [Pages] = Source.[Pages]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [Id],
                [Title],
                [ISBN],
                [PublisherId],
                [PublicationYear],
                [PublicationPlace],
                [PublicationLanguage],
                [Pages]
            )
            VALUES (
                Source.[Id],
                Source.[Title],
                Source.[ISBN],
                Source.[PublisherId],
                Source.[PublicationYear],
                Source.[PublicationPlace],
                Source.[PublicationLanguage],
                Source.[Pages]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END