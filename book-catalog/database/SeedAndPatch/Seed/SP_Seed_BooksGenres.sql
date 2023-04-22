CREATE PROCEDURE [seed].[SP_Seed_BooksGenres]
AS
BEGIN
    MERGE INTO [dbo].[BooksGenres] AS Target
    USING (VALUES
        (1, 1), -- To Kill a Mockingbird - Fiction
        (1, 2), -- To Kill a Mockingbird - Classic
        (2, 1), -- 1984 - Fiction
        (2, 3), -- 1984 - Dystopian
        (3, 1), -- One Hundred Years of Solitude - Fiction
        (3, 4), -- One Hundred Years of Solitude - Magic Realism
        (4, 1), -- Brave New World - Fiction
        (4, 3), -- Brave New World - Dystopian
        (5, 1), -- The Catcher in the Rye - Fiction
        (6, 1), -- Animal Farm - Fiction
        (6, 9), -- Animal Farm - Political Satire
        (7, 1), -- The Great Gatsby - Fiction
        (7, 5), -- The Great Gatsby - Jazz Age
        (8, 1), -- Beloved - Fiction
        (8, 6), -- Beloved - Historical Fiction
        (9, 1), -- The Color Purple - Fiction
        (9, 6), -- The Color Purple - Historical Fiction
        (10, 1), -- Slaughterhouse-Five - Fiction
        (10, 7), -- Slaughterhouse-Five - Science Fiction
        (11, 8), -- A Brief History of Time - Non-fiction
        (12, 1), -- Pride and Prejudice - Fiction
        (13, 1), -- The Hitchhiker's Guide to the Galaxy - Fiction
        (13, 7), -- The Hitchhiker's Guide to the Galaxy - Science Fiction
        (14, 1), -- The Hobbit - Fiction
        (14, 10), -- The Hobbit - Fantasy
        (15, 1), -- The Lord of the Rings - Fiction
        (15, 10), -- The Lord of the Rings - Fantasy
        (16, 11), -- The Diary of a Young Girl - Autobiography
        (17, 1), -- The Kite Runner - Fiction
        (17, 6), -- The Kite Runner - Historical Fiction
        (18, 1), -- The Alchemist - Fiction
        (18, 12), -- The Alchemist - Philosophical Fiction
        (19, 1), -- The Hunger Games - Fiction
        (19, 13), -- The Hunger Games - Young Adult Fiction
        (20, 1), -- Harry Potter and the Philosopher's Stone - Fiction
        (20, 10) -- Harry Potter and the Philosopher's Stone - Fantasy
    ) AS SOURCE (
        [BookId],
        [GenreId]
    )
        ON (Target.[BookId] = Source.[BookId] AND Target.[GenreId] = Source.[GenreId])
        WHEN NOT MATCHED BY TARGET THEN
            INSERT (
                [BookId],
                [GenreId]
            )
            VALUES (
                Source.[BookId],
                Source.[GenreId]
            )
        WHEN NOT MATCHED BY SOURCE THEN DELETE;
END