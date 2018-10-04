CREATE TABLE [dbo].[PostStatus]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostStatus PRIMARY KEY, 
	[PStatus] [varchar](255) NOT NULL CONSTRAINT UC_PostStatus UNIQUE (PStatus),
	[Description]     VARCHAR (255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date] [Date] NOT NULL DEFAULT GETDATE()
)
