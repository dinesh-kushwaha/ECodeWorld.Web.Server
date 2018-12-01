﻿CREATE TABLE [dbo].[ApproverTypes]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ApproverTypes PRIMARY KEY, 
	[Name] VARCHAR (255) NOT NULL,
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
