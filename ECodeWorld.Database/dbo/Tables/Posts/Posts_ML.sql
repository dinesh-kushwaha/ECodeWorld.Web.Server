CREATE TABLE [dbo].[Posts_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Posts_ML PRIMARY KEY, 
	[PostsID] [int] CONSTRAINT FK_Posts_MLPosts FOREIGN KEY REFERENCES Posts(ID),
	[LanguageID] [int] CONSTRAINT FK_Posts_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Title] [varchar](255) NULL,
	[Description] [varchar](500) NULL,
	[Keywords] [varchar](500) NULL,
	[Contents] [nvarchar](max) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
