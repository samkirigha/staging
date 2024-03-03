CREATE TABLE [dbo].[Orders]
(
  [ID] BIGINT IDENTITY(1, 1) NOT NULL,
  [OrderID] UNIQUEIDENTIFIER NOT NULL DEFAULT (NEWID()),
  [Description] NVARCHAR(255) NULL,
  [Price] DECIMAL(7, 2) NOT NULL DEFAULT (35.00),
  [TicketID] BIGINT NOT NULL DEFAULT (1003),
  [UserID] BIGINT NOT NULL DEFAULT (2),
  [IsDeleted] BIT NULL DEFAULT (0),
  [RowVersion] ROWVERSION,
  CONSTRAINT PK_Orders_ID PRIMARY KEY CLUSTERED ([ID]),
);
GO

CREATE NONCLUSTERED INDEX IX_Orders_OrderID
  ON [dbo].[Orders] ([OrderID])
GO

CREATE UNIQUE INDEX UQ_Orders_OrderID
  ON [dbo].[Orders] ([OrderID])
GO