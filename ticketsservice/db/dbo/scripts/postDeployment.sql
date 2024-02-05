
/*
    Categories seed data
*/
SET IDENTITY_INSERT [dbo].[Categories] ON;

WITH categoriesSeed AS
(
    SELECT * 
    FROM (
        VALUES 
            (1, '9637bd88-de85-4e29-801e-7a729ed0303b', 'sports', 0, '2024-02-01', GETDATE(), GETDATE()),
            (2, '806f8253-3a23-4804-bcfb-993b9a9edc27', 'concerts', 0, '2024-02-01', GETDATE(), GETDATE()),
            (3, '2b6c4ce4-7237-42c2-969d-b2e2d198899e', 'workshops', 0, '2024-02-01', GETDATE(), GETDATE()),
            (4, '871b37cf-49a2-467f-b3bb-4571d1ed6d71', 'ceminas', 0, '2024-02-01', GETDATE(), GETDATE())
    ) val ([ID], [CategoryID], [Name], [IsDeleted], [CreatedDTM], [UpdatedDTM], [DeletedDTM])
)

MERGE [dbo].[Categories] AS Target
USING categoriesSeed AS Source
ON Source.ID = Target.ID
WHEN NOT MATCHED BY Target THEN
    INSERT ([ID], [CategoryID], [Name], [IsDeleted], [CreatedDTM], [UpdatedDTM], [DeletedDTM])
    VALUES (Source.[ID], Source.[CategoryID], Source.[Name], Source.[IsDeleted], Source.[CreatedDTM], Source.[UpdatedDTM], Source.[DeletedDTM])
WHEN MATCHED THEN
    UPDATE SET Target.[CategoryID] = Source.[CategoryID]
        , Target.[Name] = Source.[Name]
        , Target.[IsDeleted] = Source.[IsDeleted]
        , Target.[CreatedDTM] = Source.[CreatedDTM]
        , Target.[UpdatedDTM] = Source.[UpdatedDTM]
        , Target.[DeletedDTM] = Source.[DeletedDTM];

SET IDENTITY_INSERT [dbo].[Categories] OFF;
