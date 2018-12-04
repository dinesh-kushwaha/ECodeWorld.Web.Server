CREATE TABLE [dbo].[PostsStatus]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsStatus PRIMARY KEY, 
	[PStatus] [varchar](255) NOT NULL CONSTRAINT UC_PostsStatus UNIQUE (PStatus),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
