CREATE TABLE [dbo].[PostsCategories]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsCategories PRIMARY KEY, 
	[Category] [varchar](255) NOT NULL CONSTRAINT UC_PostsCategories UNIQUE (Category),
	[Description] [varchar](255) NULL,
	[Icon] [varchar](255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
