CREATE TABLE [dbo].[TempPosts_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TempPosts_ML PRIMARY KEY, 
	[TempPostsID] [int] CONSTRAINT FK_TempPosts_MLTempPosts FOREIGN KEY REFERENCES TempPosts(ID),
	[LanguageID] [int] CONSTRAINT FK_TempPosts_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Title] [varchar](255) NULL,
	[Description] [varchar](500) NULL,
	[Keywords] [varchar](500) NULL,
	[Contents] [nvarchar](max) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniqueTempPosts_MLLanguage UNIQUE (TempPostsID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
