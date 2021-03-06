﻿CREATE TABLE [dbo].[PostTypes]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostTypes PRIMARY KEY, 
	[PType] VARCHAR (255) NOT NULL CONSTRAINT UC_PostTypes UNIQUE (PType),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date] [Date] NOT NULL DEFAULT GETDATE(),
)
