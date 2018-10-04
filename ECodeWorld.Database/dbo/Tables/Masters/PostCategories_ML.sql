CREATE TABLE [dbo].[PostCategories_ML]
(
	[ID] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PostCategories_ML PRIMARY KEY,
	[PostCategoriesID] [int] CONSTRAINT FK_TempPosts_MLPostCategories FOREIGN KEY REFERENCES PostCategories(ID),
	[LanguageID] [int] CONSTRAINT FK_PostCategories_MLLanguages FOREIGN KEY REFERENCES Languages(ID),
	[Category] [varchar](255) NOT NULL CONSTRAINT UC_PostCategories_ML UNIQUE (Category),
	[Description] [varchar](255) NULL,
	[Status] [int] NOT NULL DEFAULT 0,
	CONSTRAINT UC_UniquePostCategoryLanguage UNIQUE (PostCategoriesID,LanguageID)
)
