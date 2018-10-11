CREATE TABLE [dbo].[Roles]
(
	[ID] INT IDENTITY(1,1) NOT NULL  CONSTRAINT PK_Roles PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(150) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
--Role is collections of permission