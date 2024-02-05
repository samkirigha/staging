CREATE TABLE [dbo].[Tickets]
(
  [ID] BIGINT IDENTITY(1, 1) NOT NULL,
  [TicketID] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
  [TicketNumber] BIGINT NOT NULL,
  [DatePurchased] DATETIME DEFAULT (GETDATE()) NULL,
  [CreatedDTM] DATETIME DEFAULT (GETDATE()) NOT NULL,
  [UpdatedDTM] DATETIME DEFAULT (GETDATE()) NOT NULL,
  [IsDeleted] BIT NOT NULL DEFAULT (0),
  [CategoryID] BIGINT NULL DEFAULT (NULL),
  [RowVersion] ROWVERSION,
  CONSTRAINT PK_Tickets_ID PRIMARY KEY CLUSTERED ([ID]),
  CONSTRAINT FK_Tickets_Categories_CategoryID FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Categories] ([ID]),
);
GO

CREATE NONCLUSTERED INDEX IX_Tickets_TicketID
  ON [dbo].[Tickets] ([TicketID])
GO

CREATE UNIQUE INDEX UQ_Tickets_TicketNumber
  ON [dbo].[Tickets] ([TicketNumber])
GO

select * from [dbo].[Tickets]