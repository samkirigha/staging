CREATE TABLE [dbo].[Categories]
(
  [ID] BIGINT NOT NULL IDENTITY(1,1),
  [CategoryID] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
  [Name] NVARCHAR(50) NOT NULL,
  [IsDeleted] BIT NOT NULL CONSTRAINT DF_Categories_IsDeleted DEFAULT (0),
  [CreatedDTM] DATETIME2 NULL,
  [UpdatedDTM] DATETIME2 NULL,
  [DeletedDTM] DATETIME2 NULL,
  [RowVersion] ROWVERSION,
  CONSTRAINT PK_Categories_ID PRIMARY KEY CLUSTERED ([ID]),
);
GO

CREATE NONCLUSTERED INDEX IX_Categories_CategoryID
  ON [dbo].[Categories] ([CategoryID])
GO

CREATE UNIQUE INDEX UQ_Categories_Name
  ON [dbo].[Categories] ([Name])
GO
