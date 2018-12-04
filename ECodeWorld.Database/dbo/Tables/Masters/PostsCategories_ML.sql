CREATE TABLE [dbo].[PostsCategories_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostsCategories_ML PRIMARY KEY,
	[PostsCategoriesID] [int] CONSTRAINT FK_TempPosts_MLPostsCategories_ML FOREIGN KEY REFERENCES PostsCategories(ID),
	[LanguageID] [int] CONSTRAINT FK_PostsCategories_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Category] [varchar](255) NOT NULL CONSTRAINT UC_PostsCategories_ML UNIQUE (Category),
	[Description] [varchar](255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniquePostsCategories_MLLanguage UNIQUE (PostsCategoriesID,LanguageID),
	[Date]  DATETIME NOT NULL DEFAULT GETDATE(),
	[Timestamp] ROWVERSION  NOT NULL,
)
