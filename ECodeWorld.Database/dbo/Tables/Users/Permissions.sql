CREATE TABLE [dbo].[Permissions]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_Permissions PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
	[ActionCode] CHAR(5) NOT NULL,
	[Action] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(50) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
--Permission is collections of actions
